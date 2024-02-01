namespace TicketMicroservice.ApplicationServices
{
    public interface IChecker
    {
        Task<bool> CheckJourneyAndPassengerExistence(int journeyId, int passengerId);
    }
}
