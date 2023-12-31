using AeonTek.Charis.API.Data.ValueObjects;
using AeonTek.Charis.API.Models;

namespace AeonTek.Charis.API.Extensions
{
    public static class Transformations
    {
        public static VolunteerDto ToDto(this Volunteer volunteer)
        {
            return new VolunteerDto(volunteer.Id, volunteer.FirstName, volunteer.LastName, volunteer.Waivers.OrderByDescending(w => w.SignedDate).FirstOrDefault());
        }

        public static List<VolunteerDto> ToDto(this List<Volunteer> volunteers)
        {
            return volunteers.Select(v => v.ToDto()).ToList();
        }

        public static OrganizationDto ToDto(this Organization organization)
        {
            return new OrganizationDto(organization.Id, organization.Name);
        }

        public static List<OrganizationDto> ToDto(this List<Organization> organizations)
        {
            return organizations.Select(o => o.ToDto()).ToList();
        }

        public static WaiverTemplateDto ToDto(this WaiverTemplate template)
        {
            return new WaiverTemplateDto(template.Id, template.Version, template.UpdatedDate, template.MarkDown);
        }

        public static List<WaiverTemplateDto> ToDto(this List<WaiverTemplate> templates)
        {
            return templates.Select(o => o.ToDto()).ToList();
        }
    }
}
