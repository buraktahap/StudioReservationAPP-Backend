using Microsoft.EntityFrameworkCore;
using StudioReservationAPP.Core.Entities;
using StudioReservationAPP.Core.UoW;
using StudioReservationAPP.Models;

namespace StudioReservationAPP.Services
{
    public class MemberService : IMemberService
    {

        private readonly IUnitOfWork _unitOfWork;
        public MemberService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Member> CreateMember(Member newMember)
        {
            await _unitOfWork.Members
                .AddAsync(newMember);

            return newMember;
        }

        public async Task DeleteMember(Member Member)
        {
            _unitOfWork.Members.Remove(Member);

            await _unitOfWork.CommitAsync();
        }

        public  IQueryable<Member> GetAllMembers()
        {
            return  _unitOfWork.Members.GetAllAsync();
        }

        public async Task<Member> GetMemberById(int id)
        {
            return await _unitOfWork.Members.GetByIdAsync(id);
        }

        public async Task UpdateMember(Member MemberToBeUpdated, Member Member)
        {
            MemberToBeUpdated.Name = Member.Name;

            await _unitOfWork.CommitAsync();
        }
    }
}
