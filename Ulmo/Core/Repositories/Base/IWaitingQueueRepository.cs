using StudioReservationAPP.Core.EFContext;
using StudioReservationAPP.Core.Entities;

namespace StudioReservationAPP.Core.Repositories.Base
{
    public interface IWaitingQueueRepository : IRepository<WaitingQueue>
    {
        Task<IEnumerable<WaitingQueue>> GetAllWithWaitingQueueAsync();
        Task<WaitingQueue> GetWithWaitingQueueByIdAsync(int id);
        Task<WaitingQueue> GetWithWaitingQueueByNameAsync(string name);
    }


}
