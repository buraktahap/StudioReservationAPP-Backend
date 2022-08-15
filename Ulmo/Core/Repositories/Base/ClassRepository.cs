using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using StudioReservationAPP.Core.EFContext;
using StudioReservationAPP.Core.Entities;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace StudioReservationAPP.Core.Repositories.Base
{
    public class ClassRepository : Repository<Class>, IClassRepository
    {
        public ClassRepository(DatabaseContext context)
            : base(context)
        { }

        public async Task<IEnumerable<Class>> GetAllWithClassAsync()
        {
            return await DbContext.Classes
                .ToListAsync();
        }

        public Task<Class> GetWithClassByIdAsync(int id)
        {
            return DbContext.Classes
                .SingleOrDefaultAsync(a => a.Id == id);
        }

        public Task<Class> GetWithClassByNameAsync(string name)
        {
            return DbContext.Classes.SingleOrDefaultAsync(n=> n.Name == name);
        }

        private DatabaseContext DbContext
        {
            get { return Context as DatabaseContext; }
        }

    }
}
