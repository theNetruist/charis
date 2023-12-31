using AeonTek.Charis.API.Data.ValueObjects;

namespace AeonTek.Charis.API.Logic
{
    public interface IVolunteerLogic
    {
        Task<Contact> AddContactToVolunteer(string org, Guid volunteerId, Contact contact);
        Task<Volunteer> AddVolunteer(string org, string lastName, string? firstName);
        Task<Volunteer> GetVolunteer(string org, Guid volunteerId);
        Task<List<Volunteer>> GetVolunteers(string org);
        Task<List<Volunteer>> GetVolunteersByName(string org, string lastName, string? firstName);
        Task<Volunteer> RemoveVolunteer(string org, Guid id);
        Task<Volunteer> SignWaiver(string org, Guid volunteerId, Guid waiverId);
        Task UpdateVolunteer(string org, Guid volunteerId, string? firstName = null, string? lastName = null);
    }
}