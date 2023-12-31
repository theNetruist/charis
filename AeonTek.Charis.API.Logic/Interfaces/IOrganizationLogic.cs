using AeonTek.Charis.API.Data.ValueObjects;

namespace AeonTek.Charis.API.Logic.Interfaces
{
    public interface IOrganizationLogic
    {
        Task<Organization> AddOrganization(string name);
        Task<Organization> GetOrganization(string name);
        Task<List<Organization>> GetOrganizations();
        Task<Organization> RemoveOrganization(Guid id);
        Task SaveChanges();
    }
}
