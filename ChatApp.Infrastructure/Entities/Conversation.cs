using System;
using System.Collections.Generic;

namespace ChatApp.Infrastructure.Entities {
    public class Conversation {
        public Guid Id { get; set; }
        public List<Message> Messages { get; } = new List<Message>();
        public List<User> Users { get; } = new List<User>();
    }
}