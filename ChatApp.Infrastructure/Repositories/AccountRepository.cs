using System;
using System.Linq;
using System.Threading.Tasks;
using ChatApp.Domain;
using ChatApp.Domain.Authentication;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ChatAppContext context;
        public AccountRepository(ChatAppContext context) => this.context = context;

        public async Task CreateAccount(Account newAccount)
        {
            context.Users.Add(new Entities.User
            {
                Id = newAccount.Id,
                Email = newAccount.Email,
                Password = newAccount.HashedPassword,
                Salt = newAccount.Salt
            });

            await context.SaveChangesAsync();
        }

        public async Task<Account> GetAccountByEmail(string email)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (user == null) return null;

            return Account.CreateAccountForCheckingPassword(email, user.Password, user.Salt);
        }
    }
}
