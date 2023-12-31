using AeonTek.Charis.API.Data.ValueObjects;

namespace AeonTek.Charis.API.Data
{
    internal interface IOrganizationContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        Task<Organization> GetOrganization(Guid id);
        Task<Organization> AddOrganization(string name);
        Task<Organization> RemoveOrganization(Guid id);
        Task<List<Organization>> GetOrganizations();
        Task<Organization> GetOrganization(string name);
    }
}
