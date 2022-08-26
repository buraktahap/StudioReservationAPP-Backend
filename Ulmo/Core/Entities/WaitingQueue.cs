using System.ComponentModel.DataAnnotations;

namespace StudioReservationAPP.Core.Entities
{
    public class WaitingQueue
    {
        [Key]
        public int Id { get; set; }
        public DateTime QueueEnrollTime { get; set; }
        public int? MemberId { get; set; }
        public  Member? Member { get; set; }
        public int? LessonId { get; set; }
        public  Lesson? Lesson { get; set; }
    }
}
