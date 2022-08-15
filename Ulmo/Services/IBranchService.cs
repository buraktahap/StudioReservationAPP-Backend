using StudioReservationAPP.Core.Entities;
using StudioReservationAPP.Models;

namespace StudioReservationAPP.Services
{
    public interface IBranchService
    {
        Task<IEnumerable<Branch>> GetAllBranchs();
        Task<Branch> GetBranchById(int id);
        Task<Branch> CreateBranch(Branch newBranch);
        Task UpdateBranch(Branch BranchToBeUpdated, Branch Branch);
        Task DeleteBranch(Branch Branch);
    }
}