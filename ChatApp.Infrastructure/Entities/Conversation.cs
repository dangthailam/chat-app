using System;
using System.Collections.Generic;

namespace ChatApp.Infrastructure.Entities {
    public class Conversation {
        public Guid Id { get; set; }
        public List<Message> Messages { get; set; } = new List<Message>();
        public List<User> Users { get; set; } = new List<User>();
    }
}