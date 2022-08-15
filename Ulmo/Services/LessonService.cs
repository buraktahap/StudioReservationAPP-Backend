using Microsoft.EntityFrameworkCore;
using StudioReservationAPP.Core.Entities;
using StudioReservationAPP.Core.UoW;
using StudioReservationAPP.Models;

namespace StudioReservationAPP.Services
{
    public class LessonService : ILessonService
    {

        private readonly IUnitOfWork _unitOfWork;
        public LessonService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Lesson> CreateLesson(Lesson newLesson)
        {
            await _unitOfWork.Lessons
                .AddAsync(newLesson);

            return newLesson;
        }

        public async Task DeleteLesson(Lesson Lesson)
        {
            _unitOfWork.Lessons.Remove(Lesson);

            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Lesson>> GetAllLessons()
        {
            return await _unitOfWork.Lessons.GetAllAsync();
        }

        public async Task<Lesson> GetLessonById(int id)
        {
            return await _unitOfWork.Lessons.GetByIdAsync(id);
        }

        public async Task UpdateLesson(Lesson LessonToBeUpdated, Lesson Lesson)
        {
            LessonToBeUpdated.Name = Lesson.Name;

            await _unitOfWork.CommitAsync();
        }
    }
}
