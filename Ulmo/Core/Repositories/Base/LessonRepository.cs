using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using StudioReservationAPP.Core.EFContext;
using StudioReservationAPP.Core.Entities;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace StudioReservationAPP.Core.Repositories.Base
{
    public class LessonRepository : Repository<Lesson>, ILessonRepository
    {
        public LessonRepository(DatabaseContext context)
            : base(context)
        { }

        public async Task<IEnumerable<Lesson>> GetAllWithLessonAsync()
        {
            return await DbContext.Lessons
                .ToListAsync();
        }

        public Task<Lesson> GetWithLessonByIdAsync(int id)
        {
            return DbContext.Lessons
                .SingleOrDefaultAsync(a => a.Id == id);
        }

        public Task<Lesson> GetWithLessonByNameAsync(string name)
        {
            return DbContext.Lessons.SingleOrDefaultAsync(n => n.Name == name);
        }

        private DatabaseContext DbContext
        {
            get { return Context as DatabaseContext; }
        }

    }
}
