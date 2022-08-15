using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using StudioReservationAPP.Core.EFContext;
using StudioReservationAPP.Core.Entities;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace StudioReservationAPP.Core.Repositories.Base
{
    public class TrainerRepository : Repository<Trainer>, ITrainerRepository
    {
        public TrainerRepository(DatabaseContext context)
            : base(context)
        { }

        public async Task<IEnumerable<Trainer>> GetAllWithTrainerAsync()
        {
            return await DbContext.Trainers
                .ToListAsync();
        }

        public Task<Trainer> GetWithTrainersByIdAsync(int id)
        {
            return DbContext.Trainers
                .SingleOrDefaultAsync(a => a.Id == id);
        }

        public Task<IEnumerable<Trainer>> GetAllWithTrainersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Trainer> GetWithTrainerByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Trainer> GetWithTrainerByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        private DatabaseContext DbContext
        {
            get { return Context as DatabaseContext; }
        }

    }
}
