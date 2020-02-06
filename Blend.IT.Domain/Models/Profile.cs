using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Blend.IT.Domain.Models
{
    public class UserProfile
    {
        public int Id { get; set; }
        public string ProfileName { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
