//namespace AeonTek.Charis.API.Data.ValueObjects
//{
//    public class Event
//    {
//        public Event(string name, DateTime start, DateTime end, string? description = "", Image? primaryImage = null, List<Volunteer>? volunteers = null, string? postEventDescription = "", List<Image>? eventImages = null)
//        {
//            Id = Guid.NewGuid();
//            Name = name;
//            Description = description;
//            PrimaryImage = primaryImage;
//            Start = start;
//            End = end;
//            Volunteers = volunteers = [];
//            PostEventDescription = postEventDescription;
//            EventImages = eventImages = [];
//        }

//        private Event() { }
//        public Guid Id { get; private set; }
//        public string Name { get; private set; }
//        public string? Description { get; private set; }
//        public Image? PrimaryImage { get; private set; }
//        public DateTime Start { get; private set; }
//        public DateTime End { get; private set; }
//        public List<Volunteer> Volunteers { get; private set; } = [];
//        public string? PostEventDescription { get; private set; }
//        public List<Image> EventImages { get; private set; } = [];
//    }
//}
