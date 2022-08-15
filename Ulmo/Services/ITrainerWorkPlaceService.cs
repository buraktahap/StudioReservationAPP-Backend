using StudioReservationAPP.Core.Entities;
using StudioReservationAPP.Models;

namespace StudioReservationAPP.Services
{
    public interface ITrainerWorkPlaceService
    {
        Task<IEnumerable<TrainerWorkPlace>> GetAllTrainerWorkPlaces();
        Task<TrainerWorkPlace> GetTrainerWorkPlaceById(int id);
        Task<TrainerWorkPlace> CreateTrainerWorkPlace(TrainerWorkPlace newTrainerWorkPlace);
        Task UpdateTrainerWorkPlace(TrainerWorkPlace TrainerWorkPlaceToBeUpdated, TrainerWorkPlace TrainerWorkPlace);
        Task DeleteTrainerWorkPlace(TrainerWorkPlace TrainerWorkPlace);
    }
}