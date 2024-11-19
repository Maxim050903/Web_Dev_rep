using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WebDev.Core.Interfaces;
using WebDev.Core.Models;

namespace WebAplication.Services
{
    public class TaskServices : ITaskServices
    {
        private readonly ITaskRepository _TaskRepository;

        public TaskServices(ITaskRepository TaskRepository)
        {
            _TaskRepository = TaskRepository;
        }

        public async Task<List<_Task>> GetAllTaskForGroup(Guid id)
        {
            return await _TaskRepository.GetTasksForGroup(id);
        }

        public async Task<Guid> CreateTask(_Task task)
        {
            return await _TaskRepository.CreateTaskForGroup(task);
        }

        public async Task<Guid> DeleteTask(Guid id)
        {
            return await _TaskRepository.DeleteTask(id);
        }

        public async Task<Guid> UpdateTask(Guid id, DateTime DateCreate, DateTime DateFinish, string Description,Guid idGroup ,Guid idDiscipline, Guid idTeacher)
        {
            return await _TaskRepository.UpdateTask(id, DateCreate, DateFinish, Description,idGroup, idDiscipline, idTeacher);
        }
    }
}
