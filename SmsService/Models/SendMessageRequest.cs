using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace SmsService.Models
{
    public class SendMessageRequest : IValidatableObject
    {
        [Required]
        public string To { get; set; }

        [Required]
        [MaxLength(160)]
        public string Body { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // Phone number validation (Israeli format)
            var phoneRegex = new Regex(@"^(\+972|0)([2-9]\d{7,8})$");
            if (!phoneRegex.IsMatch(To))
            {
                yield return new ValidationResult(
                    "Invalid phone number format.",
                    new[] { nameof(To) });
            }

            // Message length check
            if (Body.Length == 0)
            {
                yield return new ValidationResult(
                    "The message cannot be empty.",
                    new[] { nameof(Body) });
            }
        }
    }
}
