using StudioReservationAPP.Core.Entities.Base;

namespace StudioReservationAPP.Core.Entities
{
    public class Lesson : Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Enums.LessonType LessonType { get; set; }
        public Enums.LessonLevel LessonLevel { get; set; }
        public string? Description { get; set; }
        public int Quota { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EstimatedTime { get; set; }
        public int TrainerId { get; set; }
        public Trainer Trainer { get; set; }
        public virtual ICollection<MemberLesson> MemberLessons { get; set; }
        //public List<MemberLesson>? EnrollmentTable { get; set; } = new List<MemberLesson>();
        public int ClassesId { get; set; }
        public Class Classes { get; set; }
    }
}
