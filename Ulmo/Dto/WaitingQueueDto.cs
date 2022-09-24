using StudioReservationAPP.Core.Entities;

namespace StudioReservationAPP.Models
{
    public class WaitingQueueDto
    {
        public int Id { get; set; }
        public DateTime QueueEnrollTime { get; set; }
        public int MemberId { get; set; }
        public virtual Member? Member { get; set; }
        public int LessonId { get; set; }
        public virtual Lesson? Lesson { get; set; }
    }
}

