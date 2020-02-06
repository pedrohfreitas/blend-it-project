using Blend.IT.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blend.IT.Domain.Interfaces
{
    public interface IStudentService
    {
        List<Student> GetAll();
        void Update(Student student);
        void Insert(Student student);
        void Delete(int Id);
    }
}
