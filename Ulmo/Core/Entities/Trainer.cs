using StudioReservationAPP.Core.Entities.Base;

namespace StudioReservationAPP.Core.Entities
{
    public class Trainer : Entity
    {
        public int Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Picture { get; set; }
        public string? Description { get; set; }

        public ICollection<Lesson> Lesson { get; set; }
        public List<TrainerWorkPlace> TrainerWorkPlaces { get; set; } = new List<TrainerWorkPlace>();
    }
}
