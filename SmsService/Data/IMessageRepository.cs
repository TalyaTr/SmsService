using System.Collections.Generic;
using System.Threading.Tasks;
using static SmsService.Shared.Enums;

namespace SmsService.Data
{
    public interface IMessageRepository
    {
        Task<Message> CreateAsync(Message message);
        Task<Message?> GetByIdAsync(Guid id);
        Task<IEnumerable<Message>> GetByStatusAsync(MessageStatus? status);
        Task UpdateStatusAsync(Guid id, MessageStatus status);
    }
}
