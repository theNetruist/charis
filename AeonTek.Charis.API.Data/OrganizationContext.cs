using AeonTek.Charis.API.Data.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace AeonTek.Charis.API.Data
{
    internal class OrganizationContext(DbContextOptions<OrganizationContext> options) : DbContext(options), IOrganizationContext
    {
        public DbSet<Organization> Organizations { get; private set; }

        public async Task<Organization> AddOrganization(string name)
        {
            var org = new Organization(name.ToUpperInvariant());
            Organizations.Add(org);
            await SaveChangesAsync();
            return org;
        }

        public async Task<Organization> GetOrganization(Guid id)
        {
            return await Organizations.Where(o => o.Id.Equals(id)).FirstOrDefaultAsync() ?? throw new KeyNotFoundException($"Organization ID \"{id}\" not found");
        }

        public async Task<List<Organization>> GetOrganizations()
        {
            return await Organizations.ToListAsync();
        }

        public async Task<Organization> GetOrganization(string name)
        {
            if (Guid.TryParse(name, out var id))
            {
                return await GetOrganization(id);
            }
            return await Organizations.Where(o => o.Name.ToUpper().Equals(name.ToUpper())).FirstOrDefaultAsync() ?? throw new KeyNotFoundException($"Organization \"{name}\" not found");
        }

        public async Task<Organization> RemoveOrganization(Guid id)
        {
            var org = await GetOrganization(id) ?? throw new KeyNotFoundException($"Organization ID \"{id}\" not found");
            Organizations.Remove(org);
            await SaveChangesAsync();
            return org;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Organization>().Property(p => p.Id).ValueGeneratedNever();
            builder.Entity<Organization>().HasIndex(p => p.Name).IsUnique();
            builder.Entity<Volunteer>().Property(p => p.Id).ValueGeneratedNever();
            //builder.Entity<Image>().Property(p => p.Id).ValueGeneratedNever();
            //builder.Entity<Event>().Property(p => p.Id).ValueGeneratedNever();
            builder.Entity<Waiver>().Property(p => p.Id).ValueGeneratedNever();
            builder.Entity<WaiverTemplate>().Property(p => p.Id).ValueGeneratedNever();
            builder.Entity<Contact>().Property(p => p.Id).ValueGeneratedNever();
            base.OnModelCreating(builder);
        }

    }


}
