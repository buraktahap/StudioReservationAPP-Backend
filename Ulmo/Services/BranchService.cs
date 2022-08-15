using Microsoft.EntityFrameworkCore;
using StudioReservationAPP.Core.Entities;
using StudioReservationAPP.Core.UoW;
using StudioReservationAPP.Models;

namespace StudioReservationAPP.Services
{
    public class BranchService : IBranchService
    {

        private readonly IUnitOfWork _unitOfWork;
        public BranchService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Branch> CreateBranch(Branch newBranch)
        {
            await _unitOfWork.Branches
                .AddAsync(newBranch);

            return newBranch;
        }

        public async Task DeleteBranch(Branch Branch)
        {
            _unitOfWork.Branches.Remove(Branch);

            await _unitOfWork.CommitAsync();
        }

        public IQueryable<Branch> GetAllBranchs()
        {
            return  _unitOfWork.Branches.GetAllAsync();
        }

        public async Task<Branch> GetBranchById(int id)
        {
            return await _unitOfWork.Branches.GetByIdAsync(id);
        }

        public async Task UpdateBranch(Branch BranchToBeUpdated, Branch Branch)
        {
            BranchToBeUpdated.Name = Branch.Name;

            await _unitOfWork.CommitAsync();
        }
    }
}
