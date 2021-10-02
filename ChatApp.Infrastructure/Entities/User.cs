using System;
using System.Collections.Generic;

namespace ChatApp.Infrastructure.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Conversation> Conversations { get; set; }

    }
}