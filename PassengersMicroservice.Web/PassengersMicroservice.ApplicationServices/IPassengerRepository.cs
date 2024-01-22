using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassengersMicroservice.Core
{
    // IPassengerRepository.cs
    public interface IPassengerRepository
    {
        List<Passenger> GetAll();
        Passenger GetById(int id);
        void Insert(Passenger passenger);
        void Update(Passenger passenger);
        void Delete(int id);
    }

    // IPassengerService.cs
    public interface IPassengerService
    {
        List<Passenger> GetAll();
        Passenger GetById(int id);
        void Insert(Passenger passengerDTO);
        void Edit(Passenger passengerDTO);
        void Delete(int id);
    }

    // PassengerService.cs
    public class PassengerService : IPassengerService
    {
        private readonly IPassengerRepository _passengerRepository;
        private readonly IMapper _mapper;

        public PassengerService(IPassengerRepository passengerRepository, IMapper mapper)
        {
            _passengerRepository = passengerRepository;
            _mapper = mapper;
        }

        public List<Passenger> GetAll()
        {
            var passengers = _passengerRepository.GetAll();
            return _mapper.Map<List<Passenger>>(passengers);
        }

        public Passenger GetById(int id)
        {
            var passenger = _passengerRepository.GetById(id);
            return _mapper.Map<Passenger>(passenger);
        }

        public void Insert(Passenger passengerDTO)
        {
            var passenger = _mapper.Map<Passenger>(passengerDTO);
            _passengerRepository.Insert(passenger);
        }

        public void Edit(Passenger passengerDTO)
        {
            var existingPassenger = _passengerRepository.GetById(passengerDTO.ID);

            if (existingPassenger == null)
            {
                // Manejar la situación en la que el pasajero no existe
                return;
            }

            _mapper.Map(passengerDTO, existingPassenger);
            _passengerRepository.Update(existingPassenger);
        }

        public void Delete(int id)
        {
            _passengerRepository.Delete(id);
        }
    }

}
