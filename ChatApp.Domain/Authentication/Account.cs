using System;
using System.Collections.Generic;
using System.Linq;
using ChatApp.Common;

namespace ChatApp.Domain
{
    public class Account
    {
        public Guid Id { get; private set; }
        public string UserName { get; private set; }
        public string Email { get; private set; }
        public string LastName { get; private set; }
        public string FirstName { get; private set; }
        public string PhoneNumber { get; private set; }
        public string HashedPassword { get; private set; }
        public string Salt { get; private set; }

        private Account()
        {
            Id = Guid.NewGuid();
        }

        public static Account CreateAccountForCheckingPassword(string email, string hashedPassword, string salt)
        {
            return new Account
            {
                Email = email,
                HashedPassword = hashedPassword,
                Salt = salt
            };
        }

        public static Account UpdateInformation(Account account)
        {
            return account;
        }

        public static Account NewAccount(string email, string password)
        {
            var saltAndPassword = SecurityHelper.GeneratePassword(password);

            Account newAccount = new Account
            {
                Email = email,
                HashedPassword = saltAndPassword.Password,
                Salt = saltAndPassword.Salt
            };

            return newAccount;
        }
    }
}
