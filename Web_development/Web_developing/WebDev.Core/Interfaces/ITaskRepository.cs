using WebDev.Core.Models;


namespace WebDev.Core.Interfaces
{
    public interface ITaskRepository
    {
        Task<Guid> CreateTaskForGroup(_Task task);
        Task<Guid> DeleteTask(Guid id);
        Task<List<_Task>> GetTasksForGroup(Guid GroupId);
        Task<Guid> UpdateTask(Guid id, DateTime DateCreate, DateTime DateFinish, string Description,Guid idGroup ,Guid idDiscipline, Guid idTeacher);
    }
}