using StudioReservationAPP.Core.Entities;
using StudioReservationAPP.Models;

namespace StudioReservationAPP.Services
{
    public interface IClassService
    {
        Task<IEnumerable<Class>> GetAllClasss();
        Task<Class> GetClassById(int id);
        Task<Class> CreateClass(Class newClass);
        Task UpdateClass(Class ClassToBeUpdated, Class Class);
        Task DeleteClass(Class Class);
    }
}