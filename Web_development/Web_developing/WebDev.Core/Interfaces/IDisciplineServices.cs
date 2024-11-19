using WebDev.Core.Models;

namespace WebAplication.Services
{
    public interface IDisciplineServices
    {
        Task<Guid> CreateDiscipline(Discipline discipline);
        Task<Guid> DeleteDiscipline(Guid id);
        Task<List<Discipline>> GetAllDisciplineForTeacher(Guid idTeacher);
        Task<Guid> UpdateDiscipline(Guid id, Guid idTeacher, Guid idGroup, string Name);
    }
}