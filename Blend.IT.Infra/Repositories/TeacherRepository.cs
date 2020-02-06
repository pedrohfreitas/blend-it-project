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
    public class TeacherRepository : ITeacherRepository
    {
        private readonly BlendITContext _context;

        public TeacherRepository(BlendITContext context)
        {
            _context = context;
        }

        public void Delete(int Id)
        {
            var teacher = _context.Teachers.Where(s => s.Id == Id).FirstOrDefault();

            _context.Teachers.Remove(teacher);

            _context.SaveChanges();
        }

        public List<Teacher> GetAll()
        {
            return _context.Teachers.ToList();
        }

        public void Insert(Teacher teacher)
        {
            _context.Teachers.Add(teacher);

            _context.SaveChanges();
        }

        public void Update(Teacher teacher)
        {
            var actualteacher = _context.Teachers.Where(s => s.Id == teacher.Id).AsNoTracking().FirstOrDefault();

            actualteacher.EnrollmentId = teacher.EnrollmentId;

            _context.Entry(actualteacher).State = EntityState.Modified;

            _context.SaveChanges();
        }
    }

}
