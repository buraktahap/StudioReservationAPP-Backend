using Microsoft.EntityFrameworkCore;
using StudioReservationAPP.Core.Entities;
using StudioReservationAPP.Core.UoW;
using StudioReservationAPP.Models;

namespace StudioReservationAPP.Services
{
    public class TrainerService : ITrainerService
    {

        private readonly IUnitOfWork _unitOfWork;
        public TrainerService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Trainer> CreateTrainer(Trainer newTrainer)
        {
            await _unitOfWork.Trainers
                .AddAsync(newTrainer);

            return newTrainer;
        }

        public async Task DeleteTrainer(Trainer Trainer)
        {
            _unitOfWork.Trainers.Remove(Trainer);

            await _unitOfWork.CommitAsync();
        }

        public IQueryable<Trainer> GetAllTrainers()
        {
            return _unitOfWork.Trainers.GetAllAsync();
        }

        public async Task<Trainer> GetTrainerById(int id)
        {
            return await _unitOfWork.Trainers.GetByIdAsync(id);
        }

        public async Task UpdateTrainer(Trainer TrainerToBeUpdated, Trainer Trainer)
        {
            TrainerToBeUpdated.First_Name = Trainer.First_Name;

            await _unitOfWork.CommitAsync();
        }
    }
}
