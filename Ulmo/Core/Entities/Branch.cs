using StudioReservationAPP.Core.Entities.Base;

namespace StudioReservationAPP.Core.Entities
{
    public class Branch : Entity
    {
        public string Name { get; set; }
        public string Location { get; set; }

        public List<TrainerWorkPlace>? TrainerWorkPlaces { get; set; } = new List<TrainerWorkPlace>();

        //public virtual Member Member { get; set; }
        public ICollection<Class>? Classes { get; set; }
        public ICollection<Lesson>? Lesson { get; set; }
    }
}
