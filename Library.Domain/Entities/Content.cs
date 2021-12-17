using Library.Domain.Common;

namespace Library.Domain.Entities
{
    public class Content
    {
        public int Id { get; set; }
        public int Localization { get; set; }
        public string Name { get; set; }
        public int DigitalEntityId { get; set; }
        public DigitalEntity DigitalEntity { get; set; }
    }
}