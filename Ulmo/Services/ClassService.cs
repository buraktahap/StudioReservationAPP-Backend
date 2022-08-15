using Microsoft.EntityFrameworkCore;
using StudioReservationAPP.Core.Entities;
using StudioReservationAPP.Core.UoW;
using StudioReservationAPP.Models;

namespace StudioReservationAPP.Services
{
    public class ClassService : IClassService
    {

        private readonly IUnitOfWork _unitOfWork;
        public ClassService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Class> CreateClass(Class newClass)
        {
            await _unitOfWork.Classes
                .AddAsync(newClass);

            return newClass;
        }

        public async Task DeleteClass(Class Class)
        {
            _unitOfWork.Classes.Remove(Class);

            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Class>> GetAllClasss()
        {
            return await _unitOfWork.Classes.GetAllAsync();
        }

        public async Task<Class> GetClassById(int id)
        {
            return await _unitOfWork.Classes.GetByIdAsync(id);
        }

        public async Task UpdateClass(Class ClassToBeUpdated, Class Class)
        {
            ClassToBeUpdated.Name = Class.Name;

            await _unitOfWork.CommitAsync();
        }
    }
}
