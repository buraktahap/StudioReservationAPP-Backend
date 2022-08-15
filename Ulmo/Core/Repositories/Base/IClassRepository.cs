using StudioReservationAPP.Core.EFContext;
using StudioReservationAPP.Core.Entities;

namespace StudioReservationAPP.Core.Repositories.Base
{
    public interface IClassRepository : IRepository<Class>
    {
        Task<IEnumerable<Class>> GetAllWithClassAsync();
        Task<Class> GetWithClassByIdAsync(int id);
        Task<Class> GetWithClassByNameAsync(string name);
    }


}
