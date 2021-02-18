using Common.FilterClasses;
using RealEstate.BLL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstate.BLL.Interfaces
{
    public interface IChatService
    {
        Task AddChat(AddChatDto addChatDto);
        Task<GetMessageDto> SendMessage(AddMessageDto messageDto);
        Task<GetChatDto> GetChat(int id, PaginationParameters paginationParams);
        Task<List<GetChatsDto>> GetAllChats();
        Task<List<string>> GetParticipants(int chatId);
    }
}
