using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using StudioReservationAPP.Core.EFContext;
using StudioReservationAPP.Core.Entities;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace StudioReservationAPP.Core.Repositories.Base
{
    public class BranchRepository : Repository<Branch>, IBranchRepository
    {
        public BranchRepository(DatabaseContext context)
            : base(context)
        { }

        public async Task<IEnumerable<Branch>> GetAllWithBranchAsync()
        {
            return await DbContext.Branches
                .ToListAsync();
        }

        public Task<Branch> GetWithBranchsByIdAsync(int id)
        {
            return DbContext.Branches
                .SingleOrDefaultAsync(a => a.Id == id);
        }

        public Task<IEnumerable<Branch>> GetAllWithBranchsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Branch> GetWithBranchByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Branch> GetWithBranchByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        private DatabaseContext DbContext
        {
            get { return Context as DatabaseContext; }
        }

    }
}
