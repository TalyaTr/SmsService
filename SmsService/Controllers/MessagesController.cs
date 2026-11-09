using Microsoft.AspNetCore.Mvc;
using SmsService.Data;
using SmsService.Models;
using SmsService.Services;
using static SmsService.Shared.Enums;

namespace SmsService.Controllers
{
    [ApiController]
    [Route("messages")]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageRepository _repository;
        private readonly IFakeSmsProvider _smsProvider;

        public MessagesController(IMessageRepository repository, IFakeSmsProvider smsProvider)
        {
            _repository = repository;
            _smsProvider = smsProvider;
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage([FromBody] SendMessageRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var message = new Message
            {
                Id = Guid.NewGuid(),
                To = request.To,
                Body = request.Body,
                Status = MessageStatus.Pending,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _repository.CreateAsync(message);

            var providerResult = await _smsProvider.SendAsync(request.To, request.Body);

            await _repository.UpdateStatusAsync(message.Id, providerResult.Status);

            return Ok(new { id = message.Id });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMessage(Guid id)
        {
            var msg = await _repository.GetByIdAsync(id);
            if (msg == null)
                return NotFound();

            return Ok(msg);
        }

        [HttpGet]
        public async Task<IActionResult> GetMessages([FromQuery] MessageStatus? status)
        {
            var messages = await _repository.GetByStatusAsync(status);
            return Ok(messages);
        }
    }
}
