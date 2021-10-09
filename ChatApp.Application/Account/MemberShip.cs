
using System;
using System.Collections.Generic;
using System.Linq;
using ChatApp.Common;
using ChatApp.Domain;
using ChatApp.Domain.Authentication;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChatApp.ApplicationService
{
    public class MemberShip : IMemberShip
    {
        private readonly IAccountRepository accountRepository;

        public MemberShip(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        public void Register(string email, string password)
        {
            Account newAccount = Account.NewAccount(email, password);
            accountRepository.CreateAccount(newAccount);
        }

        public bool Login(string email, string password)
        {
            Account account = accountRepository.GetAccountByEmail(email);
            if (account == null)
                throw new Exception("Email does not exist");

            return SecurityHelper.ConfirmPassword(account.HashedPassword, password, account.Salt);
        }
    }
}