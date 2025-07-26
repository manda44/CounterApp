namespace CounterAppBack.Domain
{
    public class Event
    {
        public int? EventId { get; set; }
        public int Count { get; set; }
        public DateTime EventDate { get; set; }
    }
}
