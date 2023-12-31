using AeonTek.Charis.API.Data.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace AeonTek.Charis.API.Data.Extensions
{
    public static class VolunteerHydrate
    {
        internal static IQueryable<Volunteer> Hydrate(this IQueryable<Volunteer> query)
        {
            return query.Include(p => p.Contacts).Include(p => p.Waivers);
        }
    }
}
