using System;
using System.Collections.Generic;
using System.Linq;
using SlackNotifier.Infrastructure.Utils.Dtos;
using SlackNotifier.Infrastructure.Utils.Enums;

namespace SlackNotifier.Infrastructure.Utils.Responses
{
    public class BaseResponse
    {
        public bool HasError => this.Messages.Any (m => m.Type == MessageType.Error);

        public List<MessageDto> Messages { get; set; }

        public BaseResponse() => this.Messages = new List<MessageDto>();

        public void AddErrorMessage(string content) => this.AddMessage(content, MessageType.Error);

        public void AddInfoMessage(string content) => this.AddMessage(content, MessageType.Info);

        public void AddSuccessMessage(string content) => this.AddMessage(content, MessageType.Success);

        public void AddWarningMessage(string content) => this.AddMessage(content, MessageType.Warning);

        private void AddMessage(string content, MessageType type) => this.Messages.Add(new MessageDto(content, type));
    }
}