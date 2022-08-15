using Microsoft.EntityFrameworkCore;
using StudioReservationAPP.Core.Entities;
using StudioReservationAPP.Core.UoW;
using StudioReservationAPP.Models;

namespace StudioReservationAPP.Services
{
    public class TrainerWorkPlaceService : ITrainerWorkPlaceService
    {

        private readonly IUnitOfWork _unitOfWork;
        public TrainerWorkPlaceService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<TrainerWorkPlace> CreateTrainerWorkPlace(TrainerWorkPlace newTrainerWorkPlace)
        {
            await _unitOfWork.TrainerWorkPlaces
                .AddAsync(newTrainerWorkPlace);

            return newTrainerWorkPlace;
        }

        public async Task DeleteTrainerWorkPlace(TrainerWorkPlace TrainerWorkPlace)
        {
            _unitOfWork.TrainerWorkPlaces.Remove(TrainerWorkPlace);

            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<TrainerWorkPlace>> GetAllTrainerWorkPlaces()
        {
            return await _unitOfWork.TrainerWorkPlaces.GetAllAsync();
        }

        public async Task<TrainerWorkPlace> GetTrainerWorkPlaceById(int id)
        {
            return await _unitOfWork.TrainerWorkPlaces.GetByIdAsync(id);
        }

        public async Task UpdateTrainerWorkPlace(TrainerWorkPlace TrainerWorkPlaceToBeUpdated, TrainerWorkPlace TrainerWorkPlace)
        {
            TrainerWorkPlaceToBeUpdated.Id = TrainerWorkPlace.Id;

            await _unitOfWork.CommitAsync();
        }
    }
}
