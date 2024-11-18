using Microsoft.EntityFrameworkCore;
using WebDev.Core.Interfaces;
using WebDev.Core.Models;
using WebDevDataBase.Entities;

namespace WebDevDataBase.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private readonly WebDevDBcontext _context;

        public GroupRepository(WebDevDBcontext context)
        {
            _context = context;
        }

        public async Task<List<Group>> GetGroups()
        {
            var GroupEntity = await _context.Groups
                .AsNoTracking().ToListAsync();

            var group = GroupEntity
                .Select(b => Group.CreateGroup(b.id, b.Name, b.id_Students).group)
                .ToList();
            return group;
        }

        public async Task<Guid> CreateGroup(Group group)
        {
            var Group_Entity = new GroupEntity
            {
                id = group.id,
                Name = group.Name,
                id_Students = group.id_Students
            };
            await _context.Groups.AddAsync(Group_Entity);
            await _context.SaveChangesAsync();

            return Group_Entity.id;
        }

        public async Task<Guid> UpdateGroup(Guid id, string Name, List<Guid> id_Students)
        {
            await _context.Groups
                .Where(x => x.id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(b => b.Name, b => Name)
                    .SetProperty(b => b.id_Students, b => id_Students));

            await _context.SaveChangesAsync();

            return id;
        }

        public async Task<Guid> DeleteGroup(Guid id)
        {
            await _context.Groups
                .Where(x => x.id == id)
                .ExecuteDeleteAsync();
            await _context.SaveChangesAsync();
            return id;
        }

    }
}
