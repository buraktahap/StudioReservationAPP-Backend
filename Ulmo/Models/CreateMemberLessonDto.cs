using StudioReservationAPP.Core.Entities;

namespace StudioReservationAPP.Models
{
    public class CreateMemberLessonDto
    {
        public bool? isEnrolled { get; set; }
        public virtual Member member{ get; set; }
        public virtual Lesson lesson { get; set; }
    }
}

