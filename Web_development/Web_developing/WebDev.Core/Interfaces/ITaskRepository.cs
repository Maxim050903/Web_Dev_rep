using Web_developing.Controllers.Request;
using WebDev.Core.Models;


namespace WebDev.Core.Interfaces
{
    public interface ITaskRepository
    {
        Task<Guid> CreateTaskForGroup(Guid GroupId, DateTime DateCreate, DateTime DateFinish, string Description, Guid idDiscipline, Guid idTeacher);
        Task<Guid> DeleteTask(Guid id);
        Task<List<_Task>> GetTasksForGroup(Guid GroupId);
        Task<Guid> UpdateTask(Guid id, DateTime DateCreate, DateTime DateFinish, string Description, Guid idDiscipline, Guid idTeacher);
    }
}