using WebDev.Core.Interfaces;
using WebDev.Core.Models;

namespace WebAplication.Services
{
    public class DisciplineServices
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

        public async Task<Guid> CreateDiscipline(Discipline discipline)
        {
            return await _disciplineRepository.CreateDiscepline(discipline);
        }

        public async Task<Guid> DeleteDiscipline (Guid id)
        {
            return await _disciplineRepository.DeleteDiscepline(id);
        }

        public async Task<Guid> UpdateDiscipline(Guid id, DisciplineRequest request)
        {
            return await _disciplineRepository.UpdateDiscepline(id, request);
        }

    }
}
