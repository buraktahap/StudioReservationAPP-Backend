using StudioReservationAPP.Core.Entities;
using StudioReservationAPP.Models;

namespace StudioReservationAPP.Services
{
    public interface IWaitingQueueService
    {
        IQueryable<WaitingQueue> GetAllWaitingQueues();
        Task<WaitingQueue> GetWaitingQueueById(int id);
        Task<WaitingQueue> CreateWaitingQueue(WaitingQueue newWaitingQueue);
        Task UpdateWaitingQueue(WaitingQueue WaitingQueueToBeUpdated, WaitingQueue WaitingQueue);
        Task DeleteWaitingQueue(WaitingQueue WaitingQueue);
    }
}