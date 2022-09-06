using StudioReservationAPP.Core.EFContext;
using StudioReservationAPP.Core.Entities;

namespace StudioReservationAPP.Core.Repositories.Base
{
    public interface IMemberLessonRepository : IRepository<MemberLesson>
    {
        IQueryable<MemberLesson> GetAllWithMemberLessonsAsync();
        Task<MemberLesson> GetWithMemberLessonByIdAsync(int id);
        Task<MemberLesson> GetWithMemberLessonByMemberIdAsync(int id);
        Task<MemberLesson> GetWithMemberLessonByLessonIdAsync(int id);
        Task<MemberLesson> GetWithMemberLessonByMemberIdAndLessonIdAsync(int memberId, int lessonId);
        Task<MemberLesson> GetWithMemberLessonByLessonNameAsync(String name);
    }


}
