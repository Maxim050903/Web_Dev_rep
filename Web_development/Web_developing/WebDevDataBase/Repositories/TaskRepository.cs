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


        public async Task<List<_Task>> GetTaskForDiscipline(Guid idDiscipline)
        {
            var tasks = await _context.Tasks
                .Where(x => x.idDiscipline == idDiscipline)
                .ToListAsync();
            var Tasks = tasks
                .Select(b => _Task.CreateTask(b.id, b.DateCreate, b.DateFinish, b.Description, b.idDiscipline, b.idGroup, b.idTeacher).task)
                .ToList();

            return Tasks;
        }

        public async Task<_Task> GetTask(Guid idTask)
        {
            var TaskEntity = _context.Tasks.FirstOrDefaultAsync(x => x.id == idTask);

            var Task_ = _Task.CreateTask
                (TaskEntity.Result.id,
                TaskEntity.Result.DateCreate,
                TaskEntity.Result.DateFinish,
                TaskEntity.Result.Description,
                TaskEntity.Result.idDiscipline,
                TaskEntity.Result.idGroup,
                TaskEntity.Result.idTeacher);

            return Task_.task;
        }


        public async Task<List<_Task>> GetTasksForStudent(Guid StudentId)
        {
            var GroupId = await _context.Groups.FirstOrDefaultAsync(x => x.id_Students.Contains(StudentId));

            var TasksEntities = await _context.Tasks
                 .Where(x => x.idGroup == GroupId.id)
                 .ToListAsync();
            var Tasks = TasksEntities
                .Select(b => _Task.CreateTask(b.id, b.DateCreate, b.DateFinish, b.Description, b.idDiscipline, b.idGroup, b.idTeacher).task)
                .ToList();
            return Tasks;
        }



        public async Task<Guid> CreateTaskForGroup(_Task task)
        {
            var TaskEntities = new TaskEntity()
            {
                id = Guid.NewGuid(),
                DateCreate = task.DateCreate,
                DateFinish = task.DateFinish,
                Description = task.Description,
                idDiscipline = task.idDiscipline,
                idGroup = task.idGroup,
                idTeacher = task.idTeacher
            };

            await _context.Tasks.AddAsync(TaskEntities);
            await _context.SaveChangesAsync();

            return TaskEntities.id;
        }

        public async Task<Guid> DeleteTask(Guid id)
        {
            await _context.Tasks
                .Where(x => x.id == id)
                .ExecuteDeleteAsync();

            await _context.SaveChangesAsync();

            return id;
        }

        public async Task<Guid> UpdateTask(Guid id, DateTime DateCreate, DateTime DateFinish, string Description, Guid idGroup , Guid idDiscipline, Guid idTeacher)
        {    
            await _context.Tasks
                .Where(x => x.id == id)
                .ExecuteUpdateAsync(t => t
                    .SetProperty(b => b.DateCreate, b => DateCreate)
                    .SetProperty(b => b.DateFinish,b => DateFinish)
                    .SetProperty(b => b.Description, b => Description)
                    .SetProperty(b => b.idDiscipline, b => idDiscipline)
                    .SetProperty(b => b.idGroup, b  =>  idGroup)
                    .SetProperty(b => b.idTeacher, b => idTeacher));

            await _context.SaveChangesAsync();

            return id;
        }
    }
}
