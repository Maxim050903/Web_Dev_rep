using Microsoft.EntityFrameworkCore;
using WebDev.Core.Interfaces;
using WebDev.Core.Models;
using WebDevDataBase.Entities;

namespace WebDevDataBase.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly WebDevDBcontext _context;

        public TeacherRepository(WebDevDBcontext context)
        {
            _context = context;
        }

        public async Task<List<Teacher>> GetTeachers()
        {
            var TeacherEntity = await _context.Teachers
                .AsNoTracking().ToListAsync();

            var Teachers = TeacherEntity
                .Select(b => Teacher.CreateTeacher(b.id, b.Name, b.SecondName, b.IndividualNumber, b.Password).teacher)
                .ToList();

            return Teachers;
        }

        public async Task<Guid> CreateTeacher(Teacher teacher)
        {
            var TeacherEntity = new TeacherEntity
            {
                id = teacher.id,
                Name = teacher.Name,
                SecondName = teacher.SecondName,
                IndividualNumber = teacher.IndividualNumber,
                Password = teacher.Password
            };

            await _context.Teachers.AddAsync(TeacherEntity);
            await _context.SaveChangesAsync();

            return teacher.id;

        }

        public async Task<Guid> UpdateTeacher(Guid id, string Name, string SecondName, ulong IndividualNumber, string Password)
        {
            await _context.Teachers
                .Where(x => x.id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(b => b.Name, b => Name)
                    .SetProperty(b => b.SecondName, b => SecondName)
                    .SetProperty(b => b.IndividualNumber, b => IndividualNumber)
                    .SetProperty(b => b.Password, b => Password));

            await _context.SaveChangesAsync();

            return id;
        }

        public async Task<Guid> DeleteTeacher(Guid id)
        {
            await _context.Teachers
                .Where(x => x.id == id)
                .ExecuteDeleteAsync();

            await _context.SaveChangesAsync();

            return id;
        }

    }
}
