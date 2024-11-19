using Microsoft.AspNetCore.Mvc;
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

        public TaskController(ITaskServices services)
        {
            _taskServices = services;
        }

        [HttpGet]
        public async Task<ActionResult<List<TaskResponse>>> GetStudents(Guid idGroup)
        {
            var tasks = await _taskServices.GetAllTaskForGroup(idGroup);
            var response = tasks.Select(b => new TaskResponse(b.id,b.DateCreate,b.DateFinish,b.Description,b.idDiscipline,b.idGroup,b.idTeacher));
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateTask([FromBody] TaskRequest request)
        {
            var (tasks, Error) = _Task.CreateTask(
                Guid.NewGuid(),
                request.DateCreate,
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

        [HttpPut]
        public async Task<ActionResult<Guid>> UpdateTask(Guid update_id, [FromBody] TaskRequest request)
        {
            await _taskServices.UpdateTask(update_id,request.DateCreate,request.DateFinish,request.Description,request.idGroup,request.idDiscipline,request.idTeacher);
            return Ok(update_id);
        }

        [HttpDelete]
        public async Task<ActionResult<Guid>> DeleteTask(Guid delete_id)
        {
            await _taskServices.DeleteTask(delete_id);
            return Ok(delete_id);
        }
    }
}
