using Microsoft.AspNetCore.Mvc;
using StudioReservationAPP.Core.Entities;

namespace StudioReservationAPP.Core.Repositories.Base
{
    public interface ITrainerWorkPlaceRepository : IRepository<TrainerWorkPlace>
    {
        Task<IEnumerable<TrainerWorkPlace>> GetAllWithTrainerWorkPlaceAsync();
        Task<TrainerWorkPlace> GetTrainerWorkPlaceByTrainerIdAsync(int id);
        Task<TrainerWorkPlace> GetTrainerWorkPlaceByBranchIdAsync(int id);
    }
}
