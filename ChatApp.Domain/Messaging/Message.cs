using System;
using System.Collections.Generic;
using System.Linq;

namespace ChatApp.Domain
{
    public enum MessageStatus
    {
        Sent = 1,
        Delivered,
        ReadBySome,
        ReadByAll
    }

    public class Message
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public User Sender { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid ConversationId { get; set; }
        public MessageStatus Status { get; set; }
        public IList<Guid> ReadByIds { get; set; }

        private Message()
        {
            Status = MessageStatus.Sent;
        }

        public static Message NewMessage(User sender, string content, Guid conversationId)
        {
            if (sender == null)
                throw new ArgumentNullException("sender");
            if (string.IsNullOrEmpty(content))
                throw new ArgumentNullException("content");

            var message = new Message
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTime.Now,
                Sender = sender,
                Content = content,
                ConversationId = conversationId,
                ReadByIds = new List<Guid> { sender.Id }
            };

            return message;
        }

        public void ReadBy(Guid userId)
        {
            if (Sender.Id == userId)
                throw new Exception("Sender already read this message");

            if (ReadByIds.Any(id => id == userId))
                throw new Exception("User already read this message");

            ReadByIds.Add(userId);
        }
    }
}
