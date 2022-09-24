using StudioReservationAPP.Core.Entities;

namespace StudioReservationAPP.Models
{
    public class MemberDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Picture { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Core.Entities.Enums.MemberType MemberType { get; set; }
        public string? Location { get; set; }



        public int? SubscriptionsId { get; set; }

        
    }
}
