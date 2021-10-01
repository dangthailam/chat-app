using System;
namespace ChatApp.Domain.Authentication
{
    public interface IAccountRepository
    {
        public Account CreateAccount(Account newAccount);
    }
}
