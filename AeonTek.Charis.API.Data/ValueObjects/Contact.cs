namespace AeonTek.Charis.API.Data.ValueObjects
{
    public class Contact
    {
        public Contact(string lastName, string? firstName, string? phoneNumber, string? emailAddress, bool allowText = false)
        {
            Id = Guid.NewGuid();
            LastName = lastName;
            FirstName = firstName;
            PhoneNumber = phoneNumber;
            EmailAddress = emailAddress;
            AllowText = allowText;
        }
        public Contact() { }
        public string LastName { get; private set; } = "";
        public string? FirstName { get; private set; }
        public string? PhoneNumber { get; private set; }
        public string? EmailAddress { get; private set; }
        public bool AllowText { get; private set; } = false;
        public Guid Id { get; private set; }
    }
}
