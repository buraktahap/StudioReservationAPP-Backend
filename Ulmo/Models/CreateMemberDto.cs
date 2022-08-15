namespace StudioReservationAPP.Models
{
    public class CreateMemberDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Core.Entities.Enums.MemberType MemberType { get; set; }
        //public int SubscriptionsId { get; set; }

    }
}
