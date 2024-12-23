using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Web_developing.Controllers.Request;
using Web_developing.Controllers.Response;
using WebAplication.Services;
using WebDev.Core.Models;

namespace Web_developing.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DisciplineController:ControllerBase
    {
        private readonly IDisciplineServices _disciplineServices;
        private readonly IGroupServices _groupServices;

        public DisciplineController(IDisciplineServices disciplineServices, IGroupServices groupServices)
        {
            _disciplineServices = disciplineServices;
            _groupServices = groupServices;
        }

        [HttpGet("{idTeacher}")]
        public async Task<ActionResult<List<DisciplineResponse>>> GetDisciplines(Guid idTeacher)
        {
            var disciplines = await _disciplineServices.GetAllDisciplineForTeacher(idTeacher);
            var groups = await _groupServices.GetAllGroups();
            List<DisciplineResponse> answer = new List<DisciplineResponse>();
            foreach (var discipline in disciplines)
            {
                List<string> Groups = new List<string>();
                foreach (var groupid in discipline.idGroups)
                {
                    foreach (var group in groups)
                    {
                        if (group.id ==  groupid)
                            Groups.Add(group.Name);
                    }
                }
                answer.Add(new DisciplineResponse(discipline.id, discipline.Name, discipline.idTeacher,Groups));
            }
            return Ok(answer);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateDiscipline([FromBody] DisciplineRequest request)
        {
            var (discipline, Error) = Discipline.CreateDiscipline(
                Guid.NewGuid(),
                request.Name,
                request.idTeacher,
                request.idGroup);
            if (!string.IsNullOrEmpty(Error))
            {
                return BadRequest(Error);
            }
            await _disciplineServices.CreateDiscipline(discipline);
            return Ok(discipline.id);
        }

        [HttpPut]
        public async Task<ActionResult<Guid>> UpdateDiscipline(Guid update_id, [FromBody] DisciplineRequest request)
        {
            await _disciplineServices.UpdateDiscipline(update_id,request.idTeacher,request.idGroup,request.Name);
            return Ok(update_id);
        }

        [HttpDelete]
        public async Task<ActionResult<Guid>> DeleteDiscipline(Guid delete_id)
        {
            await _disciplineServices.DeleteDiscipline(delete_id);
            return Ok(delete_id);
        }
    }
}
