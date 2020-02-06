using Blend.IT.Domain.Interfaces;
using Blend.IT.Domain.Models;
using Blend.IT.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blend.IT.Infra.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly BlendITContext _context;

        public StudentRepository(BlendITContext context)
        {
            _context = context;
        }

        public void Delete(int Id)
        {
            var student = _context.Students.Where(s => s.Id == Id).FirstOrDefault();

            _context.Students.Remove(student);

            _context.SaveChanges();
        }

        public List<Student> GetAll()
        {
            return _context.Students.ToList();
        }

        public void Insert(Student student)
        {
            _context.Students.Add(student);

            _context.SaveChanges();
        }

        public void Update(Student student)
        {
            var actualStudent = _context.Students.Where(s => s.Id == student.Id).AsNoTracking().FirstOrDefault();

            actualStudent.EnrollmentDate = student.EnrollmentDate;
            actualStudent.EnrollmentId = student.EnrollmentId;

            _context.Entry(actualStudent).State = EntityState.Modified;

            _context.SaveChanges();
        }
    }

}
