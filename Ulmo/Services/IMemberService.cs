using StudioReservationAPP.Core.Entities;
using StudioReservationAPP.Models;

namespace StudioReservationAPP.Services
{
    public interface IMemberService
    {
        IQueryable<Member> GetAllMembers();
        Task<Member> GetMemberById(int id);
        Task<Member> CreateMember(Member newMember);
        Task UpdateMember(Member MemberToBeUpdated, Member Member);
        Task DeleteMember(Member Member);
    }
}