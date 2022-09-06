using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using StudioReservationAPP.Core.EFContext;
using StudioReservationAPP.Core.Entities;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace StudioReservationAPP.Core.Repositories.Base
{
    public class MemberLessonRepository : Repository<MemberLesson>, IMemberLessonRepository
    {
        public MemberLessonRepository(DatabaseContext context)
            : base(context)
        { }

        public  IQueryable<MemberLesson> GetAllWithMemberLessonsAsync()
        {
            return  DbContext.MemberLessons
                .AsQueryable();
        }

        public Task<MemberLesson> GetWithMemberLessonByIdAsync(int id)
        {
            return DbContext.MemberLessons
                .SingleOrDefaultAsync(a => a.Id == id);
        }


        public Task<MemberLesson?> GetWithMemberLessonByLessonNameAsync(String name)
        {
            return DbContext.MemberLessons
    .SingleOrDefaultAsync(a => a.Lesson.Name== name);
        }

        public Task<MemberLesson> GetWithMemberLessonByMemberIdAsync(int id)
        {
            return DbContext.MemberLessons
    .SingleOrDefaultAsync(a => a.Member.Id == id);
        }

        public Task<MemberLesson> GetWithMemberLessonByLessonIdAsync(int id)
        {
            return DbContext.MemberLessons
.SingleOrDefaultAsync(a => a.Lesson.Id == id);
        }

        public Task<MemberLesson> GetWithMemberLessonByMemberIdAndLessonIdAsync(int memberId, int lessonId)
        {
            return DbContext.MemberLessons
.SingleOrDefaultAsync(a => a.Lesson.Id == lessonId && a.Member.Id == memberId);
        }


        private DatabaseContext DbContext
        {
            get { return Context as DatabaseContext; }
        }

    }
}
