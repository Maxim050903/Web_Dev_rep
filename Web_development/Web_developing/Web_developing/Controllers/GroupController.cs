using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using Web_developing.Controllers.Request;
using Web_developing.Controllers.Response;
using WebAplication.Services;
using WebDev.Core.Models;
using Group = WebDev.Core.Models.Group;

namespace Web_developing.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroupController:ControllerBase
    {
        private readonly IGroupServices _groupServices;

        public GroupController(IGroupServices groupServices)
        {
            _groupServices = groupServices;
        }

        [HttpGet]
        public async Task<ActionResult<List<GroupResponse>>> GetGroups()
        {
            var Groups = await _groupServices.GetAllGroups();
            var response = Groups.Select(g => new GroupResponse(g.id, g.Name, g.id_Students));
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateGroup([FromBody] GroupRequest request)
        {
            var (group, Error) = Group.CreateGroup(
                Guid.NewGuid(),
                request.Name,
                request.id_Students);
            if (!string.IsNullOrEmpty(Error))
            {
                return BadRequest(Error);
            }
            await _groupServices.CreateGroup(group);
            return Ok(group.id);
        }

        [HttpPut]
        public async Task<ActionResult<Guid>> UpdateGroup(Guid update_id, [FromBody] GroupRequest request)
        {
            await _groupServices.UpdateGroup(update_id, request.Name, request.id_Students);
            return Ok(update_id);
        }

        [HttpDelete]
        public async Task<ActionResult<Guid>> DeleteStudent(Guid delete_id)
        {
            await _groupServices.DeleteGroup(delete_id);
            return Ok(delete_id);
        }

    }
}
