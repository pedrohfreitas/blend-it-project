using Blend.IT.CrossCutting.FluentValidator.Validation;

namespace Blend.IT.API.Commands.Authenticate
{
    public class AuthenticateUserCommandContract : IContract
    {
        public ValidationContract Contract { get; }

        public AuthenticateUserCommandContract(AuthenticateUserCommand command)
        {
            Contract = new ValidationContract()
           .Requires()
           .IsNotNullOrEmpty(command.UserName, "Username", "O campo UserName � obrigat�rio")
           .IsNotNullOrEmpty(command.Password, "Password", "O campo Password � obrigat�rio")
           .HasMinLen(command.Password, 6, "Password", "O campo Password precisa ter no m�nimo 6 caracteres");
        }

        public AuthenticateUserCommandContract(ResetPasswordCommand command)
        {
            Contract = new ValidationContract()
           .Requires()
           .IsNotNullOrEmpty(command.Token, "Token", "O campo Token � obrigat�rio")
           .IsNotNullOrEmpty(command.password, "Password", "O campo Password � obrigat�rio")
           .HasMinLen(command.password, 6, "Password", "O campo Password precisa ter no m�nimo 6 caracteres");
        }
    }
}
