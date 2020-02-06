using Blend.IT.AppService.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blend.IT.AppService.Interfaces
{
    public interface IStudentAppService
    {
        List<StudentViewModel> GetAll();
        void Update(StudentViewModel studentViewModel);
        void Insert(StudentViewModel studentViewModel);
        void Delete(int Id);
    }
}
