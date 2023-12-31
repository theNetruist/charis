using AeonTek.Charis.API.Data;
using AeonTek.Charis.API.Data.ValueObjects;
using AeonTek.Charis.API.Logic.Interfaces;

namespace AeonTek.Charis.API.Logic.Concretes
{
    internal class OrganizationLogic(IOrganizationContext _context) : IOrganizationLogic
    {
        public async Task<Organization> GetOrganization(string name)
        {
            return await _context.GetOrganization(name);
        }

        public async Task<List<Organization>> GetOrganizations()
        {
            return await _context.GetOrganizations();
        }

        public async Task<Organization> AddOrganization(string name)
        {
            return await _context.AddOrganization(name);
        }

        public async Task<Organization> RemoveOrganization(Guid id)
        {
            return await _context.RemoveOrganization(id);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
