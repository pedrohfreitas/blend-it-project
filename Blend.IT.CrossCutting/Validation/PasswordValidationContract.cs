using System;
using System.Collections.Generic;
using System.Text;

namespace Blend.IT.CrossCutting.FluentValidator.Validation
{
    public partial class ValidationContract
    {
        /// <summary>
        /// Caso a password estiver preenchida, é obrigatório inserir a nova password e ela deve estar igual a password
        /// </summary>
        /// <param name="password"></param>
        /// <param name="newPassowrd"></param>
        /// <param name="property"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public ValidationContract ConfirmPassword(string password, string newPassowrd, string property, string message)
        {
            if (!string.IsNullOrEmpty(password))
            {
                if (!password.Equals(newPassowrd))
                {
                    AddNotification(property, message);
                }
            }

            return this;
        }
    }
}
