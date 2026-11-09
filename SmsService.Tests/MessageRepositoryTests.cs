using Microsoft.EntityFrameworkCore;
using SmsService.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SmsService.Shared.Enums;
using Xunit;

namespace SmsService.Tests
{
   
    public class MessageRepositoryTests
    {
        private SmsDbContext CreateDb()
        {
            var options = new DbContextOptionsBuilder<SmsDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new SmsDbContext(options);
        }

        [Fact]
        public async Task CreateAsync_ShouldSaveMessage()
        {
            var db = CreateDb();
            var repo = new MessageRepository(db);

            var msg = new Message
            {
                Id = Guid.NewGuid(),
                To = "0501234567",
                Body = "Hello",
                Status = MessageStatus.Pending,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await repo.CreateAsync(msg);

            var saved = await repo.GetByIdAsync(msg.Id);

            Assert.NotNull(saved);
            Assert.Equal("Hello", saved.Body);
        }

        [Fact]
        public async Task UpdateStatusAsync_ShouldChangeStatus()
        {
            var db = CreateDb();
            var repo = new MessageRepository(db);

            var msg = new Message
            {
                Id = Guid.NewGuid(),
                To = "0501234567",
                Body = "Test",
                Status = MessageStatus.Pending,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await repo.CreateAsync(msg);

            await repo.UpdateStatusAsync(msg.Id, MessageStatus.Sent);

            var updated = await repo.GetByIdAsync(msg.Id);

            Assert.Equal(MessageStatus.Sent, updated.Status);
        }
    }
}
