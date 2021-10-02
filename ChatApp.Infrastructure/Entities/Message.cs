using System;

namespace ChatApp.Infrastructure.Entities
{
    public class Message
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public Guid SenderId { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid ConversationId { get; set; }
        public int Status { get; set; }
    }
}