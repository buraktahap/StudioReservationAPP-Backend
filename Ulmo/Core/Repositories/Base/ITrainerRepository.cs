using StudioReservationAPP.Core.EFContext;
using StudioReservationAPP.Core.Entities;

namespace StudioReservationAPP.Core.Repositories.Base
{
    public interface ITrainerRepository : IRepository<Trainer>
    {
        Task<IEnumerable<Trainer>> GetAllWithTrainerAsync();
        Task<Trainer> GetWithTrainerByIdAsync(int id);
        Task<Trainer> GetWithTrainerByNameAsync(string name);
    }


}
