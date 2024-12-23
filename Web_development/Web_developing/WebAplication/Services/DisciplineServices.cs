using WebDev.Core.Interfaces;
using WebDev.Core.Models;

namespace WebAplication.Services
{
    public class DisciplineServices : IDisciplineServices
    {
        private readonly IDisciplineRepository _disciplineRepository;

        public DisciplineServices(IDisciplineRepository disciplineRepository)
        {
            _disciplineRepository = disciplineRepository;
        }

        public async Task<List<Discipline>> GetAllDisciplineForTeacher(Guid idTeacher)
        {
            return await _disciplineRepository.GetDisciplinesForTeacher(idTeacher);
        }

        public async Task<Discipline> GetDisciplineForId(Guid id)
        {
            return await _disciplineRepository.GetDisciplinesForId(id);
        }

        public async Task<Guid> CreateDiscipline(Discipline discipline)
        {
            return await _disciplineRepository.CreateDiscepline(discipline);
        }

        public async Task<Guid> DeleteDiscipline(Guid id)
        {
            return await _disciplineRepository.DeleteDiscepline(id);
        }

        public async Task<Guid> UpdateDiscipline(Guid id, Guid idTeacher, List<Guid> idGroup, string Name)
        {
            return await _disciplineRepository.UpdateDiscepline(id, idTeacher, idGroup, Name);
        }

    }
}
