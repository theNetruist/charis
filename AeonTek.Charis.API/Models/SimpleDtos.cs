using AeonTek.Charis.API.Data.ValueObjects;

namespace AeonTek.Charis.API.Models
{
    public record NameDto(string LastName, string? FirstName);
    public record SignWaiverDto(Guid VolunteerId, Guid WaiverId);
    public record VolunteerDto(Guid Id, string? FirstName, string LastName, Waiver? Waiver);
    public record WaiverTemplateDto(Guid Id, int Version, DateTime UpdatedDate, string MarkDown);
    public record OrganizationDto(Guid nId, string Name);
}
