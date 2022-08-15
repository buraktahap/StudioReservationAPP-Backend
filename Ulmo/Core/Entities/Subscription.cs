using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations.Schema;
using StudioReservationAPP.Core.Entities.Base;

namespace StudioReservationAPP.Core.Entities
{
    public class Subscription : Entity
    {
        public Enums.SubsType SubsType { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public List<Member> Members { get; set; } = new List<Member>();
    }

}
