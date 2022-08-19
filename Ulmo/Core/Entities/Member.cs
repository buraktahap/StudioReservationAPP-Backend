using StudioReservationAPP.Core.Entities.Base;

namespace StudioReservationAPP.Core.Entities
{
    public class Member : Entity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Picture { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Enums.MemberType MemberType { get; set; }
        public string? Location { get; set; }

        public virtual List<MemberLesson>? MemberLessons { get; set; } = new List<MemberLesson>();

        public WaitingQueue? WaitingQueue { get; set; }
        public int? SubscriptionsId { get; set; }

        public virtual Subscription? Subscriptions { get; set; }

        ///public virtual Branch Branch { get; set; }

        //public List<MemberLesson> EnrollmentTable { get; set; } = new List<MemberLesson>();


    }



}
