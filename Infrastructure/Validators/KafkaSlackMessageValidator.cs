using System.Linq;
using FluentValidation;

namespace SlackNotifier.Domain.Validators
{
    public class KafkaSlackMessageValidator : AbstractValidator<KafkaSlackMessage>
    {
        public KafkaSlackMessageValidator()
        {
            RuleFor(a => a.WebHookUrl)
                .Must(a => a != null && a.Any())
                .WithMessage("Enter a valid WebHookUrl.");

            RuleFor(a => a.Attachments)
                .Must(a => a is { Count: > 0 })
                .WithMessage("Attachments collection is required !");

            RuleFor(a => a.Attachments)
                .Must(a => a.FirstOrDefault() != null && !string.IsNullOrEmpty(a.FirstOrDefault()?.Text))
                .WithMessage("Attachments.Text is required !");

            RuleFor(a => a.Attachments)
                .Must(a => a.FirstOrDefault() != null && !string.IsNullOrEmpty(a.FirstOrDefault()?.Title))
                .WithMessage("Attachments.Title is required !");
        }
    }
}
 