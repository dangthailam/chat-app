using System;
using System.Threading.Tasks;

namespace ChatApp.Domain.Authentication
{
    public interface IAccountRepository
    {
        Task CreateAccount(Account newAccount);

        Task<Account> GetAccountByEmail(string email);
    }
}
