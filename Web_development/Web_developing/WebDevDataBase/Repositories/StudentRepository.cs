using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using WebDev.Core.Interfaces;
using WebDev.Core.Models;
using WebDevDataBase.Entities;

namespace WebDevDataBase.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly WebDevDBcontext _context;

        public StudentRepository(WebDevDBcontext dbcontext)
        {
            _context = dbcontext;
        }

        public async Task<List<Student>> GetStudents()
        {
            var StudentEntity = await _context.Students
                .AsNoTracking().ToListAsync();

            var Students = StudentEntity
                .Select(b => Student.CreateStudent(b.id, b.Name, b.SecondName, b.GroupName, b.IndividualNumber, b.Password).student)
                .ToList();
            return Students;
        }

        public async Task<Guid> CreateStudent(Student student)
        {
            var StudentEntity = new StudentEntity
            {
                id = student.id,
                Name = student.Name,
                SecondName = student.SecondName,
                GroupName = student.GroupName,
                IndividualNumber = student.IndividualNumber,
                Password = student.Password
            };
            await _context.Students.AddAsync(StudentEntity);
            await _context.SaveChangesAsync();

            return student.id;
        }

        public async Task<Guid> UpdateStudent(Guid id, string Name, string SecondName, ulong IndividualNumber,string GroupName ,string GroupNumber, string Password)
        {
            await _context.Students
                .Where(x => x.id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(b => b.Name, b => Name)
                    .SetProperty(b => b.SecondName, b => SecondName)
                    .SetProperty(b => b.IndividualNumber, b => IndividualNumber)
                    .SetProperty(b => b.GroupName, b => GroupName)
                    .SetProperty(b => b.Password, b => Password));

            await _context.SaveChangesAsync();

            return id;
        }

        public async Task<Guid> DeleteStudent(Guid id)
        {
            await _context.Students
                .Where(x => x.id == id)
                .ExecuteDeleteAsync();

            await _context.SaveChangesAsync();

            return id;
        }
    }
}
