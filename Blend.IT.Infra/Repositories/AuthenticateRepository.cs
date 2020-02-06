using Blend.IT.Domain.Models;
using Blend.IT.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blend.IT.Infra.Repositories
{
    public class AuthenticateRepository : IAuthenticateRepository
    {
        private readonly BlendITContext _context;

        public AuthenticateRepository(BlendITContext context)
        {
            _context = context;
        }

        public User Authenticate(string username, string password)
        {
            return _context.Users.Where(u => u.Password == password && u.UserName == username).Include(u => u.UserProfiles).FirstOrDefault();
        }
    }

}
