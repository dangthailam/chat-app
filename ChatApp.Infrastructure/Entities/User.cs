using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace ChatApp.Infrastructure.Entities
{
    public class User : IdentityUser
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string PhoneNumber { get; set; }
        public List<Conversation> Conversations { get; set; } = new List<Conversation>();
    }
}