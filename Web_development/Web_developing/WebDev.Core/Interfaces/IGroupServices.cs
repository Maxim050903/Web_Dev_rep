using WebDev.Core.Models;

namespace WebAplication.Services
{
    public interface IGroupServices
    {
        Task<Guid> CreateGroup(Group group);
        Task<Guid> DeleteGroup(Guid id);
        Task<List<Group>> GetAllGroups();
        Task<Guid> UpdateGroup(Guid id, string Name, List<Guid> id_Students);
    }
}