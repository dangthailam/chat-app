using System;
namespace ChatApp.Domain
{
    public enum MessageStatus
    {
        Sent = 1,
        Delivered,
        Read
    }

    public class Message
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public Guid SenderId { get; set; }
        public Guid ReceiverId { get; set; }
        public DateTime CreatedAt { get; set; }
        public MessageStatus Status { get; set; }

        public Message()
        {
            Status = MessageStatus.Sent;
        }
    }
}
