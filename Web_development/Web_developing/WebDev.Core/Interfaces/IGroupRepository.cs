using WebDev.Core.Models;


namespace WebDev.Core.Interfaces
{
    public interface IGroupRepository
    {
        Task<Guid> CreateGroup(Group group);
        Task<Guid> DeleteGroup(Guid id);
        Task<List<Group>> GetGroups();
        Task<Guid> UpdateGroup(Guid id, string Name, List<Guid> id_Students);
    }
}