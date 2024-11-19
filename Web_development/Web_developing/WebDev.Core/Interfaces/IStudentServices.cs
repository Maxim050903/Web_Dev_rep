using WebDev.Core.Models;

namespace WebAplication.Services
{
    public interface IStudentServices
    {
        Task<Guid> CreateStudent(Student student);
        Task<Guid> DeleteStudent(Guid id);
        Task<List<Student>> GetAllStudents();
        Task<Guid> UpdateStudent(Guid id, string Name, string SecondName, ulong IndividualNumber, string GroupName, string GroupNumber, string Password);
    }
}