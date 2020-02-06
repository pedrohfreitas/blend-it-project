using System;
using System.Collections.Generic;
using System.Linq;

namespace Blend.IT.AppService.ViewModels
{
      public class UserViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public List<UserProfileViewModel> UserProfiles { get; set; }
        
    }
}
