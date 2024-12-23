using Microsoft.EntityFrameworkCore;
using WebDev.Core.Models;
using WebDevDataBase.Entities;
using WebDev.Core.Interfaces;

namespace WebDevDataBase.Repositories
{
    public class DisciplineRepository : IDisciplineRepository
    {
        private readonly WebDevDBcontext _context;

        public DisciplineRepository(WebDevDBcontext context)
        {
            _context = context;
        }

        public async Task<List<Discipline>> GetDisciplinesForTeacher(Guid idTeacher)
        {
            var DisciplineEntities = await _context.Disciplines
                .Where(x => x.idTeacher == idTeacher)
                .ToListAsync();

            var Disciplines = DisciplineEntities
                .Select(x => Discipline.CreateDiscipline(x.id, x.Name, x.idTeacher, x.idGroups).discipline).ToList();

            return Disciplines;
        }

        public async Task<Discipline> GetDisciplinesForId(Guid id)
        {
            var DisciplineEntities = await _context.Disciplines
                .FirstOrDefaultAsync(x => x.id == id);

            var Disciplines = Discipline.CreateDiscipline(DisciplineEntities.id, DisciplineEntities.Name, DisciplineEntities.idTeacher, DisciplineEntities.idGroups).discipline;

            return Disciplines;
        }


        public async Task<Guid> CreateDiscepline(Discipline discipline)
        {
            var Discipline_Entity = new DisciplineEntity
            {
                id = discipline.id,
                Name = discipline.Name,
                idTeacher = discipline.idTeacher,
                idGroups = discipline.idGroups,
            };

            await _context.Disciplines.AddAsync(Discipline_Entity);
            await _context.SaveChangesAsync();

            return Discipline_Entity.id;
        }

        public async Task<Guid> UpdateDiscepline(Guid id, Guid idTeacher, List<Guid> idGroups, string Name)
        {
            await _context.Disciplines
                .Where(x => x.id == id)
                .ExecuteUpdateAsync(t => t
                .SetProperty(b => b.idTeacher,idTeacher)
                .SetProperty(b => b.idGroups, idGroups)
                .SetProperty(b => b.Name, Name));
            
            await _context.SaveChangesAsync();

            return id;
        }

        public async Task<Guid> DeleteDiscepline(Guid id)
        {
            await _context.Disciplines
                .Where(x => x.id == id)
                .ExecuteDeleteAsync();

            await _context.SaveChangesAsync();

            return id;
        }
    }
}
