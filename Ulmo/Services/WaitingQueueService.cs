using Microsoft.EntityFrameworkCore;
using StudioReservationAPP.Core.Entities;
using StudioReservationAPP.Core.UoW;
using StudioReservationAPP.Models;

namespace StudioReservationAPP.Services
{
    public class WaitingQueueService : IWaitingQueueService
    {

        private readonly IUnitOfWork _unitOfWork;
        public WaitingQueueService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<WaitingQueue> CreateWaitingQueue(WaitingQueue newWaitingQueue)
        {
            await _unitOfWork.WaitingQueues
                .AddAsync(newWaitingQueue);

            return newWaitingQueue;
        }

        public async Task DeleteWaitingQueue(WaitingQueue WaitingQueue)
        {
            _unitOfWork.WaitingQueues.Remove(WaitingQueue);

            await _unitOfWork.CommitAsync();
        }

        public IQueryable<WaitingQueue> GetAllWaitingQueues()
        {
            return _unitOfWork.WaitingQueues.GetAllAsync();
        }

        public async Task<WaitingQueue> GetWaitingQueueById(int id)
        {
            return await _unitOfWork.WaitingQueues.GetByIdAsync(id);
        }

        public async Task UpdateWaitingQueue(WaitingQueue WaitingQueueToBeUpdated, WaitingQueue WaitingQueue)
        {
            WaitingQueueToBeUpdated.Lesson.Name = WaitingQueue.Lesson.Name;

            await _unitOfWork.CommitAsync();
        }
    }
}
