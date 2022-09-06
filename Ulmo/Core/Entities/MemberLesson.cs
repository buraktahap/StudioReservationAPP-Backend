using System.ComponentModel.DataAnnotations.Schema;
using StudioReservationAPP.Core.Entities.Base;

namespace StudioReservationAPP.Core.Entities
{
    [Table("Enrollments")]
    public class MemberLesson : Entity
    {
        public bool? IsEnrolled { get; set; }
        //public int? EnrollCount { get; set; }
        public bool IsCheckin { get; set; } = false;
        public bool IsCompleted { get; set; } = false;

        public double? Rate { get; set; }

        public int MemberId { get; set; }
        public virtual  Member? Member { get; set; }
        public int LessonId { get; set; }
        public virtual Lesson Lesson { get; set; }
        //public Queue<MemberLesson>? WaitingQueue { get; set; }


    }

}
