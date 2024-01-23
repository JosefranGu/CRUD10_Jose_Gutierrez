using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using System;
using System.Collections.Generic;
using JourneyMicroservice.Core;

namespace JourneyMicroservice.ApplicationServices
{
    public interface IJourneyRepository
    {
        List<Journey> GetAll();
        Journey GetById(int id);
        void Insert(Journey journey);
        void Update(Journey journey);
        void Delete(int id);
    }

    // IJourneyService.cs
    public interface IJourneyService
    {
        List<Journey> GetAll();
        Journey GetById(int id);
        void Insert(Journey journeyDTO);
        void Edit(Journey journeyDTO);
        void Delete(int id);
    }

    // JourneyService.cs
    public class JourneyService : IJourneyService
    {
        private readonly IJourneyRepository _journeyRepository;
        private readonly IMapper _mapper;

        public JourneyService(IJourneyRepository journeyRepository, IMapper mapper)
        {
            _journeyRepository = journeyRepository;
            _mapper = mapper;
        }

        public List<Journey> GetAll()
        {
            var journeys = _journeyRepository.GetAll();
            return _mapper.Map<List<Journey>>(journeys);
        }

        public Journey GetById(int id)
        {
            var journey = _journeyRepository.GetById(id);
            return _mapper.Map<Journey>(journey);
        }

        public void Insert(Journey journeyDTO)
        {
            var journey = _mapper.Map<Journey>(journeyDTO);
            _journeyRepository.Insert(journey);
        }

        public void Edit(Journey journeyDTO)
        {
            var existingJourney = _journeyRepository.GetById(journeyDTO.ID);

            if (existingJourney == null)
            {
                // Manejar la situación en la que el viaje no existe
                return;
            }

            _mapper.Map(journeyDTO, existingJourney);
            _journeyRepository.Update(existingJourney);
        }

        public void Delete(int id)
        {
            _journeyRepository.Delete(id);
        }
    }
}
