using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using StudioReservationAPP.Core.EFContext;
using StudioReservationAPP.Core.Entities;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace StudioReservationAPP.Core.Repositories.Base
{
    public class WaitingQueueRepository : Repository<WaitingQueue>, IWaitingQueueRepository
    {
        public WaitingQueueRepository(DatabaseContext context)
            : base(context)
        { }

        public async Task<IEnumerable<WaitingQueue>> GetAllWithWaitingQueueAsync()
        {
            return await DbContext.WaitingQueues
                .ToListAsync();
        }

        public Task<WaitingQueue> GetWithWaitingQueueByIdAsync(int id)
        {
            return DbContext.WaitingQueues
                .SingleOrDefaultAsync(a => a.Id == id);
        }

        public Task<WaitingQueue> GetWithWaitingQueueByNameAsync(string name)
        {
            return DbContext.WaitingQueues.SingleOrDefaultAsync(n => n.Lesson.Name == name);
        }
        private DatabaseContext DbContext
        {
            get { return Context as DatabaseContext; }
        }

    }
}
