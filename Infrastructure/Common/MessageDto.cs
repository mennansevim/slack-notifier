using SlackNotifier.Infrastructure.Utils.Enums;

namespace SlackNotifier.Infrastructure.Utils.Dtos
{
    public class MessageDto
    {
        public MessageType Type { get; set; }

        public string Content { get; set; }

        public MessageDto(string content, MessageType type)
        {
            this.Content = content;
            this.Type = type;
        }
    }
}