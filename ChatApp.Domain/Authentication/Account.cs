using System;
using System.Collections.Generic;
using System.Linq;

namespace ChatApp.Domain
{
    public class Account
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }

        public static Account NewAccount(string email, string password)
        {
            return new Account
            {
                Email = email,
                Password = password
            };
        }
    }
}
