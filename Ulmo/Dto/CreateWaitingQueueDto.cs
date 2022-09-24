using StudioReservationAPP.Core.Entities;

namespace StudioReservationAPP.Models
{
    public class CreateWaitingQueueDto
    {
        public DateTime QueueEnrollTime { get; set; }
        public virtual Member member { get; set; }
        public virtual Lesson lesson { get; set; }
    }
}
