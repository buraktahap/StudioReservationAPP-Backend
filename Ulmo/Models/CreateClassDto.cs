using StudioReservationAPP.Core.Entities;

namespace StudioReservationAPP.Models
{
    public class CreateClassDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BranchId { get; set; }
        public BranchDto BranchDto { get; set; }
    }
}
