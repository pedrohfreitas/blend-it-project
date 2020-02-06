using Blend.IT.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Blend.IT.Domain.Models;
using Blend.IT.Domain.Repositories;

namespace Blend.IT.Domain.Services
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly IAuthenticateRepository _authenticateRepository;

        public AuthenticateService(IAuthenticateRepository authenticateRepository)
        {
            _authenticateRepository = authenticateRepository;
        }

        public User Authenticate(string username, string password)
        {
            User usuario = _authenticateRepository.Authenticate(username, password);

            return usuario;
        }

    }
}
