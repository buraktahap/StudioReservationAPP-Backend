using StudioReservationAPP.Core.EFContext;
using StudioReservationAPP.Core.Entities;

namespace StudioReservationAPP.Core.Repositories.Base
{
    public interface ILessonRepository : IRepository<Lesson>
    {
        Task<IEnumerable<Lesson>> GetAllWithLessonAsync();
        Task<Lesson> GetWithLessonByIdAsync(int id);
        Task<Lesson> GetWithLessonByNameAsync(string name);
    }


}
