using StudioReservationAPP.Core.EFContext;

namespace StudioReservationAPP.Core.Factory
{
    public interface IContextFactory
    {
        DatabaseContext DbContext { get; }
    }
}
