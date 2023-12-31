using AeonTek.Charis.API.Data.ValueObjects;
using AeonTek.Charis.API.Logic.Interfaces;

namespace AeonTek.Charis.API.Logic
{

    internal class VolunteerLogic(IOrganizationLogic _orgLogic) : IVolunteerLogic
    {

        public async Task<Volunteer> GetVolunteer(string org, Guid volunteerId)
        {
            return (await _orgLogic.GetOrganization(org)).GetVolunteer(volunteerId);
        }

        public async Task<List<Volunteer>> GetVolunteersByName(string org, string lastName, string? firstName)
        {
            return (await _orgLogic.GetOrganization(org)).GetVolunteersByName(lastName, firstName);
        }

        public async Task<Volunteer> AddVolunteer(string org, string lastName, string? firstName)
        {
            var volunteer = new Volunteer(lastName, firstName);
            (await _orgLogic.GetOrganization(org)).AddVolunteer(volunteer);
            await _orgLogic.SaveChanges();
            return volunteer;
        }

        public async Task<Volunteer> RemoveVolunteer(string org, Guid id)
        {
            var vol = (await _orgLogic.GetOrganization(org)).RemoveVolunteer(id);
            await _orgLogic.SaveChanges();
            return vol;
        }

        public async Task<List<Volunteer>> GetVolunteers(string org)
        {
            return (await _orgLogic.GetOrganization(org)).GetAllVolunteers();
        }

        public async Task UpdateVolunteer(string org, Guid volunteerId, string? firstName = null, string? lastName = null)
        {
            (await _orgLogic.GetOrganization(org)).GetVolunteer(volunteerId).Update(lastName, firstName);
            await _orgLogic.SaveChanges();
        }

        public async Task<Volunteer> SignWaiver(string org, Guid volunteerId, Guid waiverId)
        {
            var waiver = (await _orgLogic.GetOrganization(org)).GetTemplate(waiverId);
            var volunteer = (await _orgLogic.GetOrganization(org)).GetVolunteer(volunteerId);
            volunteer.SignWaiver(waiver);
            await _orgLogic.SaveChanges();
            return volunteer;
        }

        public async Task<Contact> AddContactToVolunteer(string org, Guid volunteerId, Contact contact)
        {
            var volunteer = (await _orgLogic.GetOrganization(org)).GetVolunteer(volunteerId);
            volunteer.AddContact(contact);
            await _orgLogic.SaveChanges();
            return contact;
        }
    }
}
