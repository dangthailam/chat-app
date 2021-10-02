using System;
using ChatApp.Domain;
using ChatApp.Domain.Authentication;

namespace ChatApp.Infrastructure
{
    public class AccountRepository : IAccountRepository
    {
        public Account CreateAccount(Account newAccount)
        {
            newAccount.Id = Guid.NewGuid();

            return newAccount;
        }
    }
}
