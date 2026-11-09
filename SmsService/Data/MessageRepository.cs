using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static SmsService.Shared.Enums;
namespace SmsService.Data
{
    public class MessageRepository : IMessageRepository
    {
        private readonly SmsDbContext _context;

        public MessageRepository(SmsDbContext context)
        {
            _context = context;
        }

        public async Task<Message> CreateAsync(Message message)
        {
            try
            {
                _context.Messages.Add(message);
                await _context.SaveChangesAsync();
                return message;
            }
            catch (Exception ex)
            {
                // log
                Console.WriteLine($"Error saving message: {ex.Message}");
                throw; 
            }
        }

        public async Task<Message?> GetByIdAsync(Guid id)
        {

            return await _context.Messages.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<Message>> GetByStatusAsync(MessageStatus? status)
        {
            if (status == null)
                return await _context.Messages.ToListAsync();

            return await _context.Messages
                .Where(m => m.Status == status)
                .ToListAsync();
        }

        public async Task UpdateStatusAsync(Guid id, MessageStatus status)
        {
            var msg = await _context.Messages.FirstOrDefaultAsync(m => m.Id == id);
            if (msg == null) return;

            msg.Status = status;
            msg.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
        }
    }
}
