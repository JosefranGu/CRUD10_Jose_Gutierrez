using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace TicketMicroservice.Web
{
    public class Checker : IChecker
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public Checker(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }

        public async Task<bool> CheckJourneyAndPassengerExistence(int journeyId, int passengerId)
        {
            var journeyExist = await CheckExistence("Journey", journeyId);
            var passengerExist = await CheckExistence("Passenger", passengerId);

            return journeyExist && passengerExist;
        }

        private async Task<bool> CheckExistence(string microserviceName, int entityId)
        {
            using (var client = _httpClientFactory.CreateClient())
            {
                // Configurar el cliente HTTP para realizar la solicitud al microservicio
                // Reemplaza "BaseApiUrl" con la URL base real de tu microservicio
                client.BaseAddress = new Uri($"http://{microserviceName}/BaseApiUrl/");
                var response = await client.GetAsync($"api/{microserviceName}/{entityId}");

                // Verificar si la solicitud fue exitosa
                if (response.IsSuccessStatusCode)
                {
                    return true; // El recurso existe
                }

                return false; // El recurso no existe o hubo un error
            }
        }
    }
}


