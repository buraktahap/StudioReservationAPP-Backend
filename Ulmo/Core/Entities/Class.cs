using StudioReservationAPP.Core.Entities.Base;

namespace StudioReservationAPP.Core.Entities
{
    public class Class : Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BranchId { get; set; }
        public Branch Branch { get; set; }
        public List<Lesson> Lessons { get; set; } = new List<Lesson>();
    }
}
