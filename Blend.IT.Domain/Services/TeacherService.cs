using Blend.IT.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Blend.IT.Domain.Models;
using Blend.IT.Domain.Repositories;

namespace Blend.IT.Domain.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeacherService(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public void Delete(int Id)
        {
            _teacherRepository.Delete(Id);
        }

        public List<Teacher> GetAll()
        {
            return _teacherRepository.GetAll();
        }

        public void Insert(Teacher teacher)
        {
            _teacherRepository.Insert(teacher);
        }

        public void Update(Teacher teacher)
        {
            _teacherRepository.Update(teacher);
        }
    }
}
