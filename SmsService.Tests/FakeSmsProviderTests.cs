using SmsService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SmsService.Shared.Enums;

namespace SmsService.Tests
{
    public class FakeSmsProviderTests
    {
        [Fact]
        public async Task SendAsync_ShouldReturnValidStatus()
        {
            var provider = new FakeSmsProvider();

            var result = await provider.SendAsync("0501234567", "Hello");

            Assert.True(result.Status == MessageStatus.Sent ||
                        result.Status == MessageStatus.Failed);

            Assert.False(string.IsNullOrEmpty(result.ProviderMessageId));
        }
    }
}
