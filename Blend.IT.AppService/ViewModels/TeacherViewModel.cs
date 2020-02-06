using System;
using System.Collections.Generic;
using System.Text;

namespace Blend.IT.AppService.ViewModels
{
    public class TeacherViewModel
    {
        public int Id { get; set; }
        public string EnrollmentId { get; set; }
        public DateTime CreatedDate { get; set; }
        public UserViewModel User { get; set; }
    }
}
