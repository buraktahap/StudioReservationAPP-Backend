using StudioReservationAPP.Core.Entities;
using StudioReservationAPP.Models;

namespace StudioReservationAPP.Services
{
    public interface ITrainerService
    {
        IQueryable<Trainer> GetAllTrainers();
        Task<Trainer> GetTrainerById(int id);
        Task<Trainer> CreateTrainer(Trainer newTrainer);
        Task UpdateTrainer(Trainer TrainerToBeUpdated, Trainer Trainer);
        Task DeleteTrainer(Trainer Trainer);
    }
}