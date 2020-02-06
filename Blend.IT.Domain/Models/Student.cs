using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Blend.IT.Domain.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string EnrollmentId { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public User User { get; set; }
    }
}
