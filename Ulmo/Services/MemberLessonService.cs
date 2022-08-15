using Microsoft.EntityFrameworkCore;
using StudioReservationAPP.Core.Entities;
using StudioReservationAPP.Core.UoW;
using StudioReservationAPP.Models;

namespace StudioReservationAPP.Services
{
    public class MemberLessonService : IMemberLessonService
    {

        private readonly IUnitOfWork _unitOfWork;
        public MemberLessonService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<MemberLesson> CreateMemberLesson(MemberLesson newMemberLesson)
        {
            await _unitOfWork.MemberLessons
                .AddAsync(newMemberLesson);

            return newMemberLesson;
        }

        public async Task DeleteMemberLesson(MemberLesson MemberLesson)
        {
            _unitOfWork.MemberLessons.Remove(MemberLesson);

            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<MemberLesson>> GetAllMemberLessons()
        {
            return await _unitOfWork.MemberLessons.GetAllAsync();
        }

        public async Task<MemberLesson> GetMemberLessonById(int id)
        {
            return await _unitOfWork.MemberLessons.GetByIdAsync(id);
        }

        public async Task<MemberLesson> GetMemberLessonByLessonId(int id)
        {
            return await _unitOfWork.MemberLessons.GetWithMemberLessonByLessonIdAsync(id);
        }

        public async Task<MemberLesson> GetMemberLessonByMemberId(int id)
        {
            return await _unitOfWork.MemberLessons.GetWithMemberLessonByMemberIdAsync(id);
        }

        public async Task UpdateMemberLesson(MemberLessonDto MemberLessonToBeUpdated, MemberLessonDto MemberLesson)
        {
            MemberLessonToBeUpdated = MemberLesson;

            await _unitOfWork.CommitAsync();
        }
    }
}
