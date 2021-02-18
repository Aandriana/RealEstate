using AutoMapper;
using RealEstate.BLL.DTO;
using RealEstate.BLL.Interfaces;
using RealEstate.DAL.Entities;
using RealEstate.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Common.FilterClasses;

namespace RealEstate.BLL.Services
{
    public class ChatService : IChatService
    {
        private readonly IAuthenticationService _authentication;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public ChatService(IAuthenticationService authenticationService, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _authentication = authenticationService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task AddChat(AddChatDto addChatDto)
        {
            var participant = await _unitOfWork.Repository<User>().GetAsync(u => u.Id == addChatDto.ParticipantId);
            if (participant != null)
            {
                var creator = await _authentication.GetCurrentUserAsync();

                addChatDto.CreatedDateUtc = DateTime.Now;
                addChatDto.CreatedById = creator.Id;

                var chat = _mapper.Map<Chat>(addChatDto);

                await _unitOfWork.Repository<Chat>().AddAsync(chat);
                await _unitOfWork.SaveChangesAsync();

                var chatCreator = new ChatUser
                {
                    UserId = creator.Id,
                    ChatId = chat.Id
                };
                var chatParticipant = new ChatUser
                {
                    UserId = addChatDto.ParticipantId,
                    ChatId = chat.Id
                };

                await _unitOfWork.Repository<ChatUser>().AddAsync(chatCreator);
                await _unitOfWork.Repository<ChatUser>().AddAsync(chatParticipant);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public async Task<GetMessageDto> SendMessage(AddMessageDto messageDto)
        {
            var chat = await _unitOfWork.Repository<Chat>().GetAsync(c => c.Id == messageDto.ChatId);
            if (chat == null) return null;

            var creator = await _authentication.GetCurrentUserAsync();
            messageDto.CreatedById = creator.Id;
            messageDto.CreatedDateUtc = DateTime.Now;
            var message = _mapper.Map<Message>(messageDto);
            await _unitOfWork.Repository<Message>().AddAsync(message);
            await _unitOfWork.SaveChangesAsync();

            var getMessage = _mapper.Map<GetMessageDto>(message);
            getMessage.FirstName = creator.FirstName;
            getMessage.LastName = creator.LastName;
            getMessage.ImagePath = creator.ImagePath;
            return getMessage;
        }
        public async Task<GetChatDto> GetChat(int id, PaginationParameters paginationParams)
        {
            var chat = await _unitOfWork.Repository<Chat>().GetAsync(c => c.Id == id);
            if (chat == null) return null;

            var messages = await _unitOfWork.Repository<Message>().GetAllAsync(m => m.ChatId == chat.Id);
            var chatDto = _mapper.Map<GetChatDto>(chat);
            var messagesDto = new List<GetMessageDto>();
            foreach (var message in messages)
            {
                var messageDto = _mapper.Map<GetMessageDto>(message);
                var user = await _unitOfWork.Repository<User>().GetAsync(u => u.Id == messageDto.CreatedById);
                messageDto.FirstName = user.FirstName;
                messageDto.LastName = user.LastName;
                messageDto.ImagePath = user.ImagePath;
                messagesDto.Add(messageDto);
            }
            chatDto.Messages = messagesDto
                .OrderByDescending(m => m.CreatedDateUtc)
                .Skip(paginationParams.Skip)
                .Take(paginationParams.Take)
                .ToList();

            return chatDto;
        }
        public async Task<List<GetChatsDto>> GetAllChats()
        {
            var user = await _authentication.GetCurrentUserAsync();
            var userChats = await _unitOfWork.Repository<ChatUser>().GetAllAsync(cu => cu.UserId == user.Id);
            if (userChats == null) return null;
            var chatsId = userChats.Select(x => x.ChatId).ToList();

             var chatsDto = new List<GetChatsDto>();

            foreach (var chatId in chatsId)
            {
                var chat = await _unitOfWork.Repository<Chat>().GetIncludingAll(c => c.Id == chatId);
                var participantId = chat.Participants.Where(u => u.UserId != user.Id).FirstOrDefault().UserId;
                var GetChatsDto = new GetChatsDto();
                var participantInfo = await _unitOfWork.Repository<User>().GetAsync(u => u.Id == participantId);
                GetChatsDto = _mapper.Map<GetChatsDto>(participantInfo);
                GetChatsDto.UserId = participantInfo.Id;
                var message = chat.Messages.LastOrDefault();
                GetChatsDto.LastMessage = message.Text;
                GetChatsDto.ChatId = chatId;
                GetChatsDto.CreatedDateUtc = message.CreatedDateUtc;
                chatsDto.Add(GetChatsDto);
            }
            return chatsDto;
        }
        public async Task<List<string>> GetParticipants(int chatId)
        {
            var chat = await _unitOfWork.Repository<Chat>().GetIncludingAll(c => c.Id == chatId);
            if (chat == null) return null;

            var receiversId = chat.Participants.Select(u => u.UserId).ToList();
            return receiversId;
        }
    }
}
