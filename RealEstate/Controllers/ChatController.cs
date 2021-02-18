using AutoMapper;
using Common.FilterClasses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using RealEstate.BLL.DTO;
using RealEstate.BLL.Interfaces;    
using RealEstate.Hubs;
using RealEstate.ViewModels;
using System.Threading.Tasks;

namespace RealEstate.Controllers
{
    [Route("api/chat")]
    [Authorize]
    public class ChatController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IChatService _chatService;

        public ChatController(IMapper mapper, IChatService chatService)
        {
            _mapper = mapper;
            _chatService = chatService;
        }

        [HttpPost]
        public async Task<IActionResult> AddChat([FromBody]AddChatViewModel addChat)
        {
            if (ModelState.IsValid)
            {
                var chatDto = _mapper.Map<AddChatDto>(addChat);
                await _chatService.AddChat(chatDto);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost("message")]
        public async Task<IActionResult> AddMessage([FromBody]AddMessageViewModel message, [FromServices] IHubContext<ChatHub> chat)
        {
            if (ModelState.IsValid)
            {
                var messageDto = _mapper.Map<AddMessageDto>(message);
                var getMessage = await _chatService.SendMessage(messageDto);
                var participants = await _chatService.GetParticipants(message.ChatId);
                var user = chat.Clients.Users(participants);
                await chat.Clients.Users(participants).SendAsync("ReceiveMessage", new
                {
                    Text = message.Text,
                    PosterFirstName = getMessage.FirstName,
                    PosterLastName = getMessage.LastName,
                    PosterLastPhoto = getMessage.ImagePath,
                    Timestamp = getMessage.CreatedDateUtc,
                    PosterId = getMessage.CreatedById
                });
                return Ok(getMessage);
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetChat(int id, [FromQuery]PaginationParameters paginationParams)
        {
            var chatDto = await _chatService.GetChat(id, paginationParams);
            var chat = _mapper.Map<GetChatViewModel>(chatDto);
            return Ok(chat);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllChats()
        {
            var getChats = await _chatService.GetAllChats();
            return Ok(getChats);
        }
    }
}
