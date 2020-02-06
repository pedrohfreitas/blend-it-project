using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blend.IT.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public List<UserProfile> UserProfiles { get; set;}
    }
}
