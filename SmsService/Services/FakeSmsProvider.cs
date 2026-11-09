using static SmsService.Shared.Enums;
using System;
using System.Threading.Tasks;

namespace SmsService.Services
{
    public class FakeSmsProvider : IFakeSmsProvider
    {
        public Task<SmsProviderResult> SendAsync(string to, string body)
        {
            var random = new Random();
            var success = random.Next(0, 100) > 10; // 90% הצלחה

            return Task.FromResult(new SmsProviderResult
            {
                Status = success ? MessageStatus.Sent : MessageStatus.Failed,
                ProviderMessageId = Guid.NewGuid().ToString()
            });
        }
    }

    public class SmsProviderResult
    {
        public MessageStatus Status { get; set; }
        public string ProviderMessageId { get; set; }
    }
}
