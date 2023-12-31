namespace AeonTek.Charis.API.Data.ValueObjects
{
    public class WaiverTemplate
    {
        public WaiverTemplate(int version, DateTime updatedDate, string markDown)
        {
            Id = Guid.NewGuid();
            Version = version;
            MarkDown = markDown;
            UpdatedDate = updatedDate;
        }
        public WaiverTemplate() { }

        public Guid Id { get; init; }
        public int Version { get; init; } = 0;
        public string MarkDown { get; init; } = "";

        private DateTime _updatedDate;
        public DateTime UpdatedDate
        {
            get { return _updatedDate; }
            init { _updatedDate = value.ToUniversalTime(); }
        }
    }
}
