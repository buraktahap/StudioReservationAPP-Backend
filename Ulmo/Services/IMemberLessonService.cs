using StudioReservationAPP.Core.Entities;
using StudioReservationAPP.Models;

namespace StudioReservationAPP.Services
{
    public interface IMemberLessonService
    {
        Task<IEnumerable<MemberLesson>> GetAllMemberLessons();
        Task<MemberLesson> GetMemberLessonById(int id);
        Task<MemberLesson> GetMemberLessonByMemberId(int id);
        Task<MemberLesson> GetMemberLessonByLessonId(int id);
        Task<MemberLesson> CreateMemberLesson(MemberLesson newMemberLesson);
        Task UpdateMemberLesson(MemberLessonDto MemberLessonToBeUpdated, MemberLessonDto MemberLesson);
        Task DeleteMemberLesson(MemberLesson MemberLesson);
    }
}