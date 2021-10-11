using System;
using MediatR;

namespace ChatApp.UI.Commands.Authentication
{
    public class LoginUserCommand: IRequest<Guid>
    {
        public LoginUserCommand()
        {
        }
    }
}
