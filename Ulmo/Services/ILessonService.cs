using StudioReservationAPP.Core.Entities;
using StudioReservationAPP.Models;

namespace StudioReservationAPP.Services
{
    public interface ILessonService
    {
        IQueryable<Lesson> GetAllLessons();
        Task<Lesson> GetLessonById(int id);
        Task<Lesson> CreateLesson(Lesson newLesson);
        Task UpdateLesson(Lesson LessonToBeUpdated, Lesson Lesson);
        Task DeleteLesson(Lesson Lesson);
    }
}