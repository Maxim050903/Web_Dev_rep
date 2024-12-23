using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WebDev.Core.Interfaces;
using WebDev.Core.Models;
using WebDevDataBase.Repositories;

namespace WebAplication.Services
{
    public class TeacherServices : ITeacherServices
    {
        private readonly ITeacherRepository _TeacherRepository;

        public TeacherServices(ITeacherRepository TeacherRepository)
        {
            _TeacherRepository = TeacherRepository;
        }

        public async Task<(bool, Guid)> LogInTeacher(ulong Number, string password)
        {
            return await _TeacherRepository.LogInTeacher(Number, password);
        }

        public async Task<List<Teacher>> GetAllTeacher()
        {
            return await _TeacherRepository.GetTeachers();
        }

        public async Task<Guid> CreateTeacher(Teacher teacher)
        {
            return await _TeacherRepository.CreateTeacher(teacher);
        }

        public async Task<Teacher> GetTeacher(Guid id)
        {
            return await _TeacherRepository.GetTeacher(id);
        }

        public async Task<Guid> DeleteTeacher(Guid id)
        {
            return await _TeacherRepository.DeleteTeacher(id);
        }

        public async Task<Guid> UpdateTeacher(Guid id, string Name, string SecondName, ulong IndividualNumber, string Password)
        {
            return await _TeacherRepository.UpdateTeacher(id, Name, SecondName, IndividualNumber, Password);
        }
    }
}
