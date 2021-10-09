using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatApp.Common;
using ChatApp.Domain;
using ChatApp.Domain.Authentication;
using ChatApp.UI.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChatApp.UI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        [HttpPost("/register")]
        public void Register(AuthenticationModel model)
        {
            Account newAccount = Account.NewAccount(model.Email, model.Password);
            accountRepository.CreateAccount(newAccount);
        }

        [HttpPost("/login")]
        public bool Login(AuthenticationModel model)
        {
            Account account = accountRepository.GetAccountByEmail(model.Email);
            if (account == null)
                throw new Exception("Email does not exist");

            return SecurityHelper.ConfirmPassword(account.HashedPassword, model.Password, account.Salt);
        }
    }
}
