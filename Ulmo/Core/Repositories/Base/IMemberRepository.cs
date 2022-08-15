using StudioReservationAPP.Core.EFContext;
using StudioReservationAPP.Core.Entities;

namespace StudioReservationAPP.Core.Repositories.Base
{
    public interface IMemberRepository : IRepository<Member>
    {
        Task<IEnumerable<Member>> GetAllWithMembersAsync();
        Task<Member> GetWithMemberByIdAsync(int id);
        Task<Member> GetWithMemberByNameAsync(string name);
    }


}
