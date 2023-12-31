namespace AeonTek.Charis.API.Data.ValueObjects
{
    public class Volunteer
    {
        public Volunteer() { }
        public Volunteer(string lastName, string? firstName = null)
        {
            Id = Guid.NewGuid();
            LastName = lastName.ToUpper();
            FirstName = firstName?.ToUpper();
            Contacts = [];
            Waivers = [];
        }

        public Guid Id
        {
            get;
            private set;
        }
        public string LastName { get; private set; } = "";
        public string? FirstName { get; private set; }
        //public Image Image { get; private set; }
        public virtual List<Contact> Contacts { get; private set; } = [];
        public virtual List<Waiver> Waivers { get; private set; } = [];

        public Waiver SignWaiver(WaiverTemplate waiver)
        {
            var signedWaiver = new Waiver(Guid.NewGuid(), waiver.Version, DateTime.UtcNow);
            Waivers.Add(signedWaiver);
            return signedWaiver;
        }

        public Volunteer AddContact(Contact contact)
        {
            Contacts.Add(contact);
            return this;
        }

        public Volunteer Update(string? lastName = null, string? firstName = null)
        {
            if (firstName != null) FirstName = firstName;
            if (lastName != null) LastName = lastName;
            return this;
        }

    }
}
