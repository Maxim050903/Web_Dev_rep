using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Web_developing.Controllers.Response;
using WebAplication.Services;

namespace Web_developing.Controllers
{
    [ApiController]
    [Route("[controller]")] 
    public class AuthController: ControllerBase
    {
        private readonly IStudentServices _studentServices;
        private readonly ITeacherServices _teacherService;

        public AuthController(IStudentServices studentServices, ITeacherServices teacherService)
        {
            _studentServices = studentServices;
            _teacherService = teacherService;
        }

        [HttpGet]
        public async Task<ActionResult<AuthResponse>> LogIn(ulong IndividualNumber, string password)
        {
            string role = string.Empty;

            (bool answer, Guid id) = await _studentServices.LogInStudent(IndividualNumber, password);
            if (answer)
            {
                var response = new AuthResponse("student",id);
                return Ok(response);
            }
            (answer, id) = await _teacherService.LogInTeacher(IndividualNumber, password);
            if (answer)
            {
                var response = new AuthResponse("teacher", id);
                return Ok(response);
            }
            
            return BadRequest("Повторите ввод");
        }
    }
}
