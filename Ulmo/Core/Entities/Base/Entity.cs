namespace StudioReservationAPP.Core.Entities.Base
{
    public abstract class Entity<TPrimaryKey>
    {
        public TPrimaryKey Id { get; set; }
    }

    public abstract class Entity : Entity<int>
    {

    }
}
