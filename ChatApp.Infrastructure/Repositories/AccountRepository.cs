using System;
using System.Linq;
using ChatApp.Domain;
using ChatApp.Domain.Authentication;

namespace ChatApp.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ChatAppContext context;
        public AccountRepository(ChatAppContext context) => this.context = context;
        public void CreateAccount(Account newAccount)
        {
            context.Users.Add(new Entities.User
            {
                Id = newAccount.Id,
                Email = newAccount.Email,
                Password = newAccount.HashedPassword,
                Salt = newAccount.Salt
            });

            context.SaveChanges();
        }

        public Account GetAccountByEmail(string email)
        {
            var user = context.Users.FirstOrDefault(u => u.Email == email);

            if (user == null) return null;

            return Account.CreateAccountForCheckingPassword(email, user.Password, user.Salt);
        }
    }
}
