namespace JourneyMicroservice.Core
{
    public class Journey
    {
        public int ID { get; set; }
        public int DestinationId { get; set; }
        public int OriginId { get; set; }
        public DateTime Departure { get; set; }
        public DateTime Arrival { get; set; }
    }
}
