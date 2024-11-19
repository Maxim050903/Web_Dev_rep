using System.Xml.Linq;
using WebDev.Core.Interfaces;
using WebDev.Core.Models;

namespace WebAplication.Services
{
    public class StudentServices : IStudentServices
    {
        private readonly IStudentRepository _StudentRepository;

        public StudentServices(IStudentRepository StudentRepository)
        {
            _StudentRepository = StudentRepository;
        }

        public async Task<List<Student>> GetAllStudents()
        {
            return await _StudentRepository.GetStudents();
        }

        public async Task<Guid> CreateStudent(Student student)
        {
            return await _StudentRepository.CreateStudent(student);
        }

        public async Task<Guid> DeleteStudent(Guid id)
        {
            return await _StudentRepository.DeleteStudent(id);
        }

        public async Task<Guid> UpdateStudent(Guid id, string Name, string SecondName, ulong IndividualNumber, string GroupName, string GroupNumber, string Password)
        {
            return await _StudentRepository.UpdateStudent(id, Name, SecondName, IndividualNumber, GroupName, GroupNumber, Password);
        }
    }
}
