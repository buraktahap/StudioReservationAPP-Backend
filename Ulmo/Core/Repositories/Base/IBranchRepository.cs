using StudioReservationAPP.Core.EFContext;
using StudioReservationAPP.Core.Entities;

namespace StudioReservationAPP.Core.Repositories.Base
{
    public interface IBranchRepository : IRepository<Branch>
    {
        Task<IEnumerable<Branch>> GetAllWithBranchsAsync();
        Task<Branch> GetWithBranchByIdAsync(int id);
        Task<Branch> GetWithBranchByNameAsync(string name);
    }


}
