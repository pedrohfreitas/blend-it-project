using AutoMapper;
using Blend.IT.AppService.Interfaces;
using Blend.IT.AppService.ViewModels;
using Blend.IT.Domain.Interfaces;
using Blend.IT.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blend.IT.AppService.Services
{
    public class StudentAppService : IStudentAppService
    {
        private readonly IStudentService _studentService;

        public StudentAppService(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public void Delete(int Id)
        {
            _studentService.Delete(Id);
        }

        public List<StudentViewModel> GetAll()
        {
            List<Student> students = _studentService.GetAll();

            List<StudentViewModel> studentsViewModel = Mapper.Map<List<StudentViewModel>>(students);

            return studentsViewModel;
        }

        public void Insert(StudentViewModel studentViewModel)
        {
            Student student = Mapper.Map<Student>(studentViewModel);

            _studentService.Insert(student);
        }

        public void Update(StudentViewModel studentViewModel)
        {
            Student student = Mapper.Map<Student>(studentViewModel);

            _studentService.Update(student);
        }
    }
}
