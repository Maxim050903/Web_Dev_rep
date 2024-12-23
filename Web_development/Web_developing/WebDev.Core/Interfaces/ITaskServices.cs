using WebDev.Core.Models;

namespace WebAplication.Services
{
    public interface ITaskServices
    {
        Task<Guid> CreateTask(_Task task);
        Task<Guid> DeleteTask(Guid id);
        Task<List<_Task>> GetAllTaskForGroup(Guid id);
        Task<Guid> UpdateTask(Guid id, DateTime DateCreate, DateTime DateFinish, string Description,Guid idGroup ,Guid idDiscipline, Guid idTeacher);
        Task<List<_Task>> GetTasksForStudent(Guid id);
        Task<_Task> GetTask(Guid idTask);
        Task<List<_Task>> GetTaskForDiscipline(Guid idDiscipline);
    }
}