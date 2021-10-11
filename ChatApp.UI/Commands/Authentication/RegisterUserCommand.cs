using System;
using ChatApp.UI.Contracts;

namespace ChatApp.UI.Commands.Authentication
{
    public class RegisterUserCommand : CommandBase<Guid>
    {
        public string Email { get; }
        public string Password { get; }
        public string Username { get; }

        public RegisterUserCommand(string email, string password, string username)
        {
            Email = email;
            Password = password;
            Username = username;
        }
    }
}
