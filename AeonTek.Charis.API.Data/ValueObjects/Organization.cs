namespace AeonTek.Charis.API.Data.ValueObjects
{
    public class Organization
    {
        public Organization(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
        public Organization() { }

        public Guid Id { get; private set; }
        public string Name { get; private set; } = "";
        public virtual List<WaiverTemplate> WaiverTemplates { get; private set; } = [];
        //public List<Event> Events { get; private set; } = [];
        public virtual List<Volunteer> Volunteers { get; private set; } = [];

        /// <exception cref="KeyNotFoundException" />
        public WaiverTemplate GetCurrentTemplate()
        {
            return WaiverTemplates.OrderByDescending(w => w.Version).FirstOrDefault() ?? throw new KeyNotFoundException($"No waiver templates have been saved for this organization.");
        }

        /// <exception cref="KeyNotFoundException" />
        public WaiverTemplate GetTemplate(Guid id)
        {
            return WaiverTemplates.FirstOrDefault(w => w.Id == id) ?? throw new KeyNotFoundException($"Waiver template ID \"{id}\" not found");
        }

        public WaiverTemplate AddTemplate(string markdown)
        {
            var version = 1;
            try
            {
                var current = GetCurrentTemplate();
                version = current.Version + 1;
            }
            catch (KeyNotFoundException) {/* Ignore - this just means that there are no existing templates. */ }
            var waiver = new WaiverTemplate(version, DateTime.UtcNow, markdown);
            WaiverTemplates.Add(waiver);
            return waiver;
        }

        public List<WaiverTemplate> GetAllTemplates()
        {
            return WaiverTemplates.ToList();
        }

        //public Event AddEvent(Event ev)
        //{
        //    Events.Add(ev);
        //    return ev;
        //}

        //public Event RemoveEvent(Guid id)
        //{
        //    var ev = GetEvent(id);
        //    Events.Remove(ev);
        //    return ev;
        //}

        ///// <exception cref="KeyNotFoundException" />
        //public Event GetEvent(Guid id)
        //{
        //    return Events.Where(e => e.Id == id).FirstOrDefault() ?? throw new KeyNotFoundException($"Event ID \"{id}\" not found"); ;
        //}

        //public List<Event> GetAllEvents()
        //{
        //    return Events.ToList();
        //}

        public Volunteer AddVolunteer(Volunteer volunteer)
        {
            Volunteers.Add(volunteer);
            return volunteer;
        }

        public Volunteer RemoveVolunteer(Guid id)
        {
            var volunteer = GetVolunteer(id);
            Volunteers.Remove(volunteer);
            return volunteer;
        }

        /// <exception cref="KeyNotFoundException" />
        public Volunteer GetVolunteer(Guid id)
        {
            return Volunteers.Where(e => e.Id == id).FirstOrDefault() ?? throw new KeyNotFoundException($"Volunteer ID \"{id}\" not found");
        }

        public List<Volunteer> GetAllVolunteers()
        {
            return Volunteers.ToList();
        }

        public List<Volunteer> GetVolunteersByName(string lastName, string? firstName)
        {
            return Volunteers.Where(e => e.LastName == lastName && (firstName == null || firstName == e.FirstName)).ToList();
        }
    }
}
