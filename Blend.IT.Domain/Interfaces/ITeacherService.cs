using Blend.IT.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blend.IT.Domain.Interfaces
{
    public interface ITeacherService
    {
        List<Teacher> GetAll();
        void Update(Teacher teacher);
        void Insert(Teacher teacher);
        void Delete(int Id);
    }
}
