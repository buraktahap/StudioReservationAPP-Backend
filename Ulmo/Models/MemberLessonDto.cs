using StudioReservationAPP.Core.Entities;

namespace StudioReservationAPP.Models
{
    public class MemberLessonDto
    {
        public int id;
        public bool? isEnrolled { get; set; }
        public int? EnrollCount { get; set; }
        public bool? isCheckin { get; set; }
        public bool? isCompleted { get; set; }
        public int? memberId { get; set; }
        public int? lessonId { get; set; }

        public virtual LessonDto Lesson { get; set; }


    }
}
