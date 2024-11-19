using Microsoft.AspNetCore.Mvc;
using Web_developing.Controllers.Request;
using Web_developing.Controllers.Response;
using WebAplication.Services;
using WebDev.Core.Models;

namespace Web_developing.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherServices _teacherServices;
        
        public TeacherController(ITeacherServices teacherServices) 
        {
            _teacherServices = teacherServices;
        }

        [HttpGet]
        public async Task<ActionResult<List<TeacherResponse>>> GetTeachers()
        {
            var teachers = await _teacherServices.GetAllTeacher();
            var response = teachers.Select(b => new TeacherResponse(b.id,b.Name,b.SecondName,b.IndividualNumber,b.Password));
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateTeacher([FromBody] TeacherRequest request)
        {
            var (teacher, Error) = Teacher.CreateTeacher(
                Guid.NewGuid(),
                request.Name,
                request.SeconName,
                request.IndividualNumber,
                request.Password);
            if (!string.IsNullOrEmpty(Error))
            {
                return BadRequest(Error);
            }
            await _teacherServices.CreateTeacher(teacher);
            return Ok(teacher.id);
        }

        [HttpPut]
        public async Task<ActionResult<Guid>> UpdateTeacher(Guid update_id, [FromBody] TeacherRequest request)
        {
            var id = await _teacherServices.UpdateTeacher(update_id,request.Name, request.SeconName, request.IndividualNumber, request.Password);
            return Ok(id);
        }

        [HttpDelete]
        public async Task<ActionResult<Guid>> DeleteTeacher(Guid delete_id)
        {
            await _teacherServices.DeleteTeacher(delete_id);
            return Ok(delete_id);
        }
    }
}
