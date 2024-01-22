using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PassengersMicroservice.Core;

namespace PassengersMicroservice.Web
{
    // PassengerRepository.cs
    public class PassengerRepository : IPassengerRepository
    {
        private readonly DbContext _dbContext;

        public PassengerRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Passenger> GetAll()
        {
            return _dbContext.Set<Passenger>().ToList();
        }

        public Passenger GetById(int id)
        {
            return _dbContext.Set<Passenger>().FirstOrDefault(p => p.ID == id);
        }

        public void Insert(Passenger passenger)
        {
            _dbContext.Set<Passenger>().Add(passenger);
            _dbContext.SaveChanges();
        }

        public void Update(Passenger passenger)
        {
            _dbContext.Entry(passenger).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var passenger = _dbContext.Set<Passenger>().FirstOrDefault(p => p.ID == id);

            if (passenger != null)
            {
                _dbContext.Set<Passenger>().Remove(passenger);
                _dbContext.SaveChanges();
            }
        }
    }

}
