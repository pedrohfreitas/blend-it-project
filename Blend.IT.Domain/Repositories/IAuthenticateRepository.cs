using System;
using System.Collections.Generic;
using System.Text;
using Blend.IT.Domain.Models;

namespace Blend.IT.Domain.Repositories
{
    public interface IAuthenticateRepository
    {
        User Authenticate(string username, string password);
    }
}
