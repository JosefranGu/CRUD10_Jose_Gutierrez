namespace TicketMicroservice.Web
{
    public interface IChecker
    {
        Task<bool> CheckJourneyAndPassengerExistence(int journeyId, int passengerId);
    }
}
