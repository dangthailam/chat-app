using System;
using System.Threading;
using System.Threading.Tasks;
using ChatApp.Domain;
using ChatApp.Domain.Authentication;
using ChatApp.UI.Contracts;
using MediatR;

namespace ChatApp.UI.Commands.Authentication
{
    public class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand, Guid>
    {
        private readonly IAccountRepository accountRepository;

        public RegisterUserCommandHandler(IAccountRepository accountRepository) => this.accountRepository = accountRepository;

        public async Task<Guid> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            Account newAccount = Account.NewAccount(request.Email, request.Password);

            await accountRepository.CreateAccount(newAccount);

            return newAccount.Id;
        }
    }
}
