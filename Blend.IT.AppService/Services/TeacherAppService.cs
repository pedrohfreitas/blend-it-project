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
    public class TeacherAppService : ITeacherAppService
    {
        private readonly ITeacherService _teacherService;

        public TeacherAppService(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        public void Delete(int Id)
        {
            _teacherService.Delete(Id);
        }

        public List<TeacherViewModel> GetAll()
        {
            List<Teacher> teachers = _teacherService.GetAll();

            List<TeacherViewModel> studentsViewModel = Mapper.Map<List<TeacherViewModel>>(teachers);

            return studentsViewModel;
        }

        public void Insert(TeacherViewModel teacherViewModel)
        {
            Teacher teacher = Mapper.Map<Teacher>(teacherViewModel);

            _teacherService.Insert(teacher);
        }

        public void Update(TeacherViewModel teacherViewModel)
        {
            Teacher teacher = Mapper.Map<Teacher>(teacherViewModel);

            _teacherService.Update(teacher);
        }
    }
}
