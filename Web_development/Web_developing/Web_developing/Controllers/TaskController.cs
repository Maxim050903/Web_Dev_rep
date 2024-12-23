using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Web_developing.Controllers.Request;
using Web_developing.Controllers.Response;
using WebAplication.Services;
using WebDev.Core.Models;

namespace Web_developing.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskServices _taskServices;
        private readonly ITeacherServices _teacherServices;
        private readonly IDisciplineServices _disciplineServices;

        public TaskController(ITaskServices services, ITeacherServices teacherServices, IDisciplineServices disciplineServices)
        {
            _taskServices = services;
            _teacherServices = teacherServices;
            _disciplineServices = disciplineServices;
        }

        [HttpGet("{idTask}")]
        public async Task<ActionResult<TaskResponseOne>> GetTask(Guid idTask)
        {
            var task = await _taskServices.GetTask(idTask);
            var discipline = await _disciplineServices.GetDisciplineForId(task.idDiscipline);

            var response = new TaskResponseOne(task.DateFinish, task.Description, discipline.Name);

            return Ok(response);
        }

        [HttpGet("/bydiscipline/{idDiscipline}")]
        public async Task<ActionResult<TaskResponseOne>> GetTasksForDiscipline(Guid idDiscipline)
        {
            var tasks = await _taskServices.GetTaskForDiscipline(idDiscipline);
            var response = new List<TaskResponseForStiudentPage>();

            foreach (var value in tasks)
            {
                var Discipline = await _disciplineServices.GetDisciplineForId(value.idDiscipline);

                var teacher = await _teacherServices.GetTeacher(Discipline.idTeacher);

                response.Add(new TaskResponseForStiudentPage(value.id, Discipline.Name, value.DateFinish, value.Description, teacher.Name));
            }
            return Ok(response);
        }


        [HttpGet]
        public async Task<ActionResult<List<TaskResponseForStiudentPage>>> GetTaskForStudent(Guid StudentId)
        {
            var tasks = await _taskServices.GetTasksForStudent(StudentId);

            var response = new List<TaskResponseForStiudentPage>();

            foreach (var value in tasks)
            {
                var Discipline = await _disciplineServices.GetDisciplineForId(value.idDiscipline);

                var teacher = await _teacherServices.GetTeacher(Discipline.idTeacher);

                response.Add(new TaskResponseForStiudentPage(value.id, Discipline.Name, value.DateFinish, value.Description, teacher.Name));
            }
            return Ok(response);
        }

        [HttpPost("/createTask")]
        public async Task<ActionResult<Guid>> CreateTask([FromBody] TaskRequest request)
        {
            var (tasks, Error) = _Task.CreateTask(
                Guid.NewGuid(),
                DateTime.UtcNow,
                request.DateFinish,
                request.Description,
                request.idDiscipline,
                request.idGroup,
                request.idTeacher);
            if (!string.IsNullOrEmpty(Error))
            {
                return BadRequest(Error);
            }
            await _taskServices.CreateTask(tasks);
            return Ok(tasks.id);
        }

        [HttpPut("{update_id}")]
        public async Task<ActionResult<Guid>> UpdateTask(Guid update_id, [FromBody] TaskUpdateRequest request)
        {
            var task = await _taskServices.GetTask(update_id);
            await _taskServices.UpdateTask(update_id,task.DateCreate,request.DateFinish,request.Description,task.idGroup,task.idDiscipline,task.idTeacher);
            return Ok(update_id);
        }

        [HttpDelete("{delete_id}")]
        public async Task<ActionResult<Guid>> DeleteTask(Guid delete_id)
        {
            Console.WriteLine(delete_id.GetType());
            await _taskServices.DeleteTask(delete_id);
            return Ok(delete_id);
        }


    }
}
