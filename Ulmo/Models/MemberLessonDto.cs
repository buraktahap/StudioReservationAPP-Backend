using StudioReservationAPP.Core.Entities;

namespace StudioReservationAPP.Models
{
    public class MemberLessonDto
    {
        public int Id;
        public bool? IsEnrolled { get; set; }
        public int? EnrollCount { get; set; }
        public bool? IsCheckin { get; set; }
        public bool? IsCompleted { get; set; }
        public int? MemberId { get; set; }
        public int? LessonId { get; set; }
        public virtual Member Member { get; set; }
        public  virtual LessonDto Lesson { get; set; }
        public double? Rate { get; internal set; }
        public string ClassName { get; internal set; }
    }
}
