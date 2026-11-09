using static SmsService.Shared.Enums;

namespace SmsService.Data
{
    public class Message
    {
        public Guid Id { get; set; }
        public string To { get; set; }
        public string Body { get; set; }
        public MessageStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
