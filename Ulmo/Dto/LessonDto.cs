using StudioReservationAPP.Core.Entities;

namespace StudioReservationAPP.Models
{
    public class LessonDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Core.Entities.Enums.LessonType LessonType { get; set; }
        public Core.Entities.Enums.LessonLevel LessonLevel { get; set; }
        public string? Description { get; set; }
        public int EnrollQuota { get; set; }
        public int WaitingQueueQuota { get; set; }
        public int EnrollCount { get; set; } 
        public int WaitingQueueCount { get; set; } 
        public DateTime StartDate { get; set; }
        public DateTime EstimatedTime { get; set; }
        public int TrainerId { get; set; }
        public TrainerDto Trainer { get; set; }
        public virtual ICollection<MemberLesson> MemberLessons { get; set; }
        //public List<MemberLesson>? EnrollmentTable { get; set; } = new List<MemberLesson>();
        public int ClassesId { get; set; }
        public ClassDto Classes { get; set; }
        public bool IsEnrolled { get; internal set; }
        public double Rate { get; set; }

    }
}