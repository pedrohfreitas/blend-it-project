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
           .IsNotNullOrEmpty(command.UserName, "Username", "O campo UserName é obrigatório")
           .IsNotNullOrEmpty(command.Password, "Password", "O campo Password é obrigatório")
           .HasMinLen(command.Password, 6, "Password", "O campo Password precisa ter no mínimo 6 caracteres");
        }

        public AuthenticateUserCommandContract(ResetPasswordCommand command)
        {
            Contract = new ValidationContract()
           .Requires()
           .IsNotNullOrEmpty(command.Token, "Token", "O campo Token é obrigatório")
           .IsNotNullOrEmpty(command.password, "Password", "O campo Password é obrigatório")
           .HasMinLen(command.password, 6, "Password", "O campo Password precisa ter no mínimo 6 caracteres");
        }
    }
}
