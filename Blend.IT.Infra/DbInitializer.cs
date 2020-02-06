using Blend.IT.CrossCutting.Util;
using Blend.IT.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blend.IT.Infra
{
    public static class DbInitializer
    {
        public static void Initialize(BlendITContext context)
        {
            context.Database.EnsureCreated();

            if (context.Users.Any())
            {
                return;
            }

            string defaultPassword = Password.MD5Hash("789!QAZ@");

            #region USER_TEACHER
            var user1 = new User
            {
                UserName = "pedroteacher",
                Password = defaultPassword,
                Email = "pedrofreitas@outlook.com",
            };

            var userProfiles1 = new List<UserProfile>()
            {
                new UserProfile { ProfileName = "Teacher" , User = user1},
            };

            user1.UserProfiles = userProfiles1;

            var teacher1 = new Teacher
            {
                EnrollmentId = "2020A1",
                CreatedDate = DateTime.Now,
                User = user1
            };

            context.Users.Add(user1);
            context.Teachers.Add(teacher1);
            #endregion

            #region USER_STUDENT
            var user2 = new User
            {
                UserName = "pedrostudent",
                Password = defaultPassword,
                Email = "pedrofreitas@outlook.com",
            };

            var userProfiles2 = new List<UserProfile>()
            {
                new UserProfile { ProfileName = "Student" , User = user1},
            };

            user2.UserProfiles = userProfiles2;

            var student2 = new Student
            {
                EnrollmentId = "2020A2",
                EnrollmentDate = DateTime.Now,
                CreatedDate = DateTime.Now,
                User = user2
            };

            context.Users.Add(user2);
            context.Students.Add(student2);
            #endregion

            context.SaveChanges();
        }
    }
}
