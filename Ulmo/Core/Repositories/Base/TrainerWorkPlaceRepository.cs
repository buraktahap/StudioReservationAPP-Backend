using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using StudioReservationAPP.Core.EFContext;
using StudioReservationAPP.Core.Entities;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace StudioReservationAPP.Core.Repositories.Base
{
    public class TrainerWorkPlaceRepository : Repository<TrainerWorkPlace>, ITrainerWorkPlaceRepository
    {
        public TrainerWorkPlaceRepository(DatabaseContext context)
            : base(context)
        { }

        public async Task<IEnumerable<TrainerWorkPlace>> GetAllWithTrainerWorkPlaceAsync()
        {
            return await DbContext.TrainerWorkPlaces
                .ToListAsync();
        }

        public Task<TrainerWorkPlace> GetTrainerWorkPlaceByTrainerIdAsync(int id)
        {
            return DbContext.TrainerWorkPlaces
                .SingleOrDefaultAsync(a => a.TrainerId == id);
        }
        public Task<TrainerWorkPlace> GetTrainerWorkPlaceByBranchIdAsync(int id)
        {
            return DbContext.TrainerWorkPlaces
                .SingleOrDefaultAsync(a => a.BranchId == id);
        }

        private DatabaseContext DbContext
        {
            get { return Context as DatabaseContext; }
        }

    }
}
