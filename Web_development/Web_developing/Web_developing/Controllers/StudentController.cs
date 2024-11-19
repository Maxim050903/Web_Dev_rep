using Microsoft.AspNetCore.Mvc;
using Web_developing.Controllers.Request;
using Web_developing.Controllers.Response;
using WebAplication.Services;
using WebDev.Core.Models;


namespace Web_developing.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController:ControllerBase
    {
        private readonly IStudentServices _studentService;

        public StudentController(IStudentServices studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<ActionResult<List<StudentResponse>>> GetStudents()
        {
            var students = await _studentService.GetAllStudents();
            var response = students.Select(b => new StudentResponse(b.id, b.Name, b.SecondName,b.GroupName,b.IndividualNumber, b.Password));
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateStudents([FromBody] StudentRequest request)
        {
            var (student, Error) = Student.CreateStudent(
                Guid.NewGuid(),
                request.Name,
                request.SecondName,
                request.GroupName,
                request.IndividualNumber,
                request.Password);
            if (!string.IsNullOrEmpty(Error))
            {
                return BadRequest(Error);
            }
            await _studentService.CreateStudent(student);
            return Ok(student.id);
        }

        [HttpPut]
        public async Task<ActionResult<Guid>> UpdateStudent(Guid update_id, [FromBody] StudentRequest request)
        {
            var id = await _studentService.UpdateStudent(update_id,request.Name,request.SecondName,request.IndividualNumber,request.GroupName,request.GroupNumber,request.Password);
            return Ok(id);
        }

        [HttpDelete]
        public async Task<ActionResult<Guid>> DeleteStudent(Guid delete_id)
        {
            var id = await _studentService.DeleteStudent(delete_id);
            return Ok(id);
        }
    }
}
