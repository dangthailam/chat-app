using System;
namespace ChatApp.Domain.Authentication
{
    public interface IAccountRepository
    {
        void CreateAccount(Account newAccount);

        Account GetAccountByEmail(string email);
    }
}
