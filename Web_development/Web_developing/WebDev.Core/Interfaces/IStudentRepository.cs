using WebDev.Core.Models;


namespace WebDev.Core.Interfaces
{ 
    public interface IStudentRepository
    {
        Task<Guid> CreateStudent(Student student);
        Task<Guid> DeleteStudent(Guid id);
        Task<List<Student>> GetStudents();
        Task<Guid> UpdateStudent(Guid id, string Name, string SecondName, ulong IndividualNumber,string GroupName, string GroupNumber, string Password);
        Task<(bool, Guid)> LogInStudent(ulong Number, string password);
    }
}