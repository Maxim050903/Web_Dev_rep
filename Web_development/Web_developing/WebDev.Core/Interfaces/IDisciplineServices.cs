using WebDev.Core.Models;

namespace WebAplication.Services
{
    public interface IDisciplineServices
    {
        Task<Guid> CreateDiscipline(Discipline discipline);
        Task<Guid> DeleteDiscipline(Guid id);
        Task<List<Discipline>> GetAllDisciplineForTeacher(Guid idTeacher);
        Task<Guid> UpdateDiscipline(Guid id, Guid idTeacher, List<Guid> idGroup, string Name);
        Task<Discipline> GetDisciplineForId(Guid id);
    }
}