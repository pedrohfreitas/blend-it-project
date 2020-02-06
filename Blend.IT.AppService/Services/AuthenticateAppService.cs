using Blend.IT.AppService.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Blend.IT.Domain.Models;
using Blend.IT.Domain.Interfaces;
using AutoMapper;
using Blend.IT.AppService.ViewModels;
using Blend.IT.CrossCutting.Util;
using System.Security.Cryptography;
using Blend.IT.API.Commands.Authenticate;
using Blend.IT.CrossCutting;
using Newtonsoft.Json.Linq;

namespace Blend.IT.AppService.Services
{
    public class AuthenticateAppService : IAuthenticateAppService
    {
        private readonly IAuthenticateService _authenticateService;

        public AuthenticateAppService(IAuthenticateService authenticateService)
        {
            _authenticateService = authenticateService;
        }

        public UserViewModel Authenticate(string username, string password)
        {
            password = Password.MD5Hash(password);

            User user = _authenticateService.Authenticate(username, password);

            UserViewModel userViewModel = Mapper.Map<UserViewModel>(user);

            return userViewModel;
        }
    }
}
