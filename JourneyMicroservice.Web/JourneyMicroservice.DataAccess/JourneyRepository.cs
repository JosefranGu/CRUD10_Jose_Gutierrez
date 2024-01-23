using JourneyMicroservice.ApplicationServices;
using JourneyMicroservice.Core;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
namespace JourneyMicroservice.DataAccess
{
    public class JourneyRepository : IJourneyRepository
    {
        private readonly DbContext _dbContext;

        public JourneyRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Journey> GetAll()
        {
            return _dbContext.Set<Journey>().ToList();
        }

        public Journey GetById(int id)
        {
            return _dbContext.Set<Journey>().FirstOrDefault(j => j.ID == id);
        }

        public void Insert(Journey journey)
        {
            _dbContext.Set<Journey>().Add(journey);
            _dbContext.SaveChanges();
        }

        public void Update(Journey journey)
        {
            _dbContext.Entry(journey).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var journey = _dbContext.Set<Journey>().FirstOrDefault(j => j.ID == id);

            if (journey != null)
            {
                _dbContext.Set<Journey>().Remove(journey);
                _dbContext.SaveChanges();
            }
        }
    }


}

