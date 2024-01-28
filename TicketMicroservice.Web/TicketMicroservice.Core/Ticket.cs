namespace TicketMicroservice.Core
{
    public class Ticket
    {
        public int ID { get; set; }
        public int JourneyId { get; set; }
        public int PassengerId { get; set; }
        public int Seat { get; set; }
    }
}
