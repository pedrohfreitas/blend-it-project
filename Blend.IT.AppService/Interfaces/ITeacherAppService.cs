using Blend.IT.AppService.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blend.IT.AppService.Interfaces
{
    public interface ITeacherAppService
    {
        List<TeacherViewModel> GetAll();
        void Update(TeacherViewModel teacherView);
        void Insert(TeacherViewModel teacherView);
        void Delete(int Id);
    }
}
