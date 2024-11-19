using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDev.Core.Interfaces;
using WebDev.Core.Models;

namespace WebAplication.Services
{
    public class GroupServices : IGroupServices
    {
        private readonly IGroupRepository _GroupRepository;

        public GroupServices(IGroupRepository GroupRepository)
        {
            _GroupRepository = GroupRepository;
        }

        public async Task<List<Group>> GetAllGroups()
        {
            return await _GroupRepository.GetGroups();
        }

        public async Task<Guid> CreateGroup(Group group)
        {
            return await _GroupRepository.CreateGroup(group);
        }

        public async Task<Guid> DeleteGroup(Guid id)
        {
            return await _GroupRepository.DeleteGroup(id);
        }

        public async Task<Guid> UpdateGroup(Guid id, string Name, List<Guid> id_Students)
        {
            return await _GroupRepository.UpdateGroup(id, Name, id_Students);
        }
    }
}
