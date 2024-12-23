using WebDev.Core.Models;


namespace WebDev.Core.Interfaces
{
    public interface ITeacherRepository
    {
        Task<Guid> CreateTeacher(Teacher teacher);
        Task<Guid> DeleteTeacher(Guid id);
        Task<List<Teacher>> GetTeachers();
        Task<Guid> UpdateTeacher(Guid id, string Name, string SecondName, ulong IndividualNumber, string Password);
        Task<Teacher> GetTeacher(Guid id);
        Task<(bool, Guid)> LogInTeacher(ulong Number, string password);
    }
}