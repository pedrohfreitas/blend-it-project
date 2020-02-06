using Blend.IT.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Blend.IT.Domain.Models;
using Blend.IT.Domain.Repositories;

namespace Blend.IT.Domain.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public void Delete(int Id)
        {
            _studentRepository.Delete(Id);
        }

        public List<Student> GetAll()
        {
            return _studentRepository.GetAll();
        }

        public void Insert(Student student)
        {
            _studentRepository.Insert(student);
        }

        public void Update(Student student)
        {
            _studentRepository.Update(student);
        }

    }
}
