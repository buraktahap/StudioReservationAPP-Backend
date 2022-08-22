using StudioReservationAPP.Core.Entities;

namespace StudioReservationAPP.Models
{
    public class MemberLessonDto
    {
        public int id;
        public bool? IsEnrolled { get; set; }
        public int? EnrollCount { get; set; }
        public bool? IsCheckin { get; set; }
        public bool? IsCompleted { get; set; }
        public int? MemberId { get; set; }
        public int? LessonId { get; set; }
        public virtual Member Member { get; set; }
        public  LessonDto Lesson { get; set; }


    }
}
