using Blend.IT.API.Commands.Authenticate;
using Blend.IT.AppService.ViewModels;
using Blend.IT.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blend.IT.AppService.Interfaces
{
    public interface IAuthenticateAppService
    {
        UserViewModel Authenticate(string username, string password);
    }
}
