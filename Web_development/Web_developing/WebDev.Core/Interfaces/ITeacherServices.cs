using WebDev.Core.Models;

namespace WebAplication.Services
{
    public interface ITeacherServices
    {
        Task<Guid> CreateTeacher(Teacher teacher);
        Task<Guid> DeleteTeacher(Guid id);
        Task<List<Teacher>> GetAllTeacher();
        Task<Guid> UpdateTeacher(Guid id, string Name, string SecondName, ulong IndividualNumber, string Password);
    }
}