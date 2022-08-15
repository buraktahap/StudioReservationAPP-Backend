using StudioReservationAPP.Core.Entities.Base;

namespace StudioReservationAPP.Core.Entities
{
    public class TrainerWorkPlace : Entity
    {
        public int TrainerId { get; set; }
        public Trainer Trainer { get; set; }
        public int? BranchId { get; set; }
        public Branch? Branch { get; set; }

        
    }
}
