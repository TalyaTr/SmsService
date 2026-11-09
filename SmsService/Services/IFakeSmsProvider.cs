using System.Threading.Tasks;

namespace SmsService.Services
{
    public interface IFakeSmsProvider
   {
        Task<SmsProviderResult> SendAsync(string to, string body);
    }
}
