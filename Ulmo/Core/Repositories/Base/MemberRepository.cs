using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using StudioReservationAPP.Core.EFContext;
using StudioReservationAPP.Core.Entities;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace StudioReservationAPP.Core.Repositories.Base
{
    public class MemberRepository : Repository<Member>, IMemberRepository
    {
        public MemberRepository(DatabaseContext context)
            : base(context)
        { }

        public async Task<IEnumerable<Member>> GetAllWithMemberAsync()
        {
            return await DbContext.Members
                .ToListAsync();
        }

        public Task<Member> GetWithMembersByIdAsync(int id)
        {
            return DbContext.Members
                .SingleOrDefaultAsync(a => a.Id == id);
        }

        public Task<IEnumerable<Member>> GetAllWithMembersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Member> GetWithMemberByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Member> GetWithMemberByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        private DatabaseContext DbContext
        {
            get { return Context as DatabaseContext; }
        }

    }
}
