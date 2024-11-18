using Microsoft.EntityFrameworkCore;
using WebDev.Core.Interfaces;
using WebDev.Core.Models;
using WebDevDataBase.Entities;

namespace WebDevDataBase.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        public readonly WebDevDBcontext _context;

        public TaskRepository(WebDevDBcontext context)
        {
            _context = context;
        }

        public async Task<List<_Task>> GetTasksForGroup(Guid GroupId)
        {
            var TasksEntities = await _context.Tasks
                .Where(x => x.idGroup == GroupId)
                .ToListAsync();
            var Tasks = TasksEntities
                .Select(b => _Task.CreateTask(b.id, b.DateCreate, b.DateFinish, b.Description, b.idDiscipline, b.idGroup, b.idTeacher).task)
                .ToList();
            return Tasks;
        }

        public async Task<Guid> CreateTaskForGroup(Guid GroupId, DateTime DateCreate, DateTime DateFinish, string Description, Guid idDiscipline, Guid idTeacher)
        {
            var TaskEntities = new TaskEntity()
            {
                id = Guid.NewGuid(),
                DateCreate = DateCreate,
                DateFinish = DateFinish,
                Description = Description,
                idDiscipline = idDiscipline,
                idGroup = GroupId,
                idTeacher = idTeacher
            };

            await _context.Tasks.AddAsync(TaskEntities);
            await _context.SaveChangesAsync();

            return TaskEntities.id;
        }

        public async Task<Guid> DeleteTask(Guid id)
        {
            await _context.Tasks
                .Select(x => x.id)
                .ExecuteDeleteAsync();

            await _context.SaveChangesAsync();

            return id;
        }

        public async Task<Guid> UpdateTask(Guid id, DateTime DateCreate, DateTime DateFinish, string Description, Guid idDiscipline, Guid idTeacher)
        {
            await _context.Tasks
                .Where(x => x.id == id)
                .ExecuteUpdateAsync(t => t
                .SetProperty(b => b.DateCreate, DateCreate)
                .SetProperty(b => b.DateFinish, DateFinish)
                .SetProperty(b => b.Description, Description)
                .SetProperty(b => b.idDiscipline, idDiscipline)
                .SetProperty(b => b.idGroup, idGroup)
                .SetProperty(b => b.idTeacher, idTeacher));

            await _context.SaveChangesAsync();

            return id;
        }
    }
}
