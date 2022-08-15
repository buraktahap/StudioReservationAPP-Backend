using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StudioReservationAPP.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainerWorkPlaceDto : ControllerBase
    {
        public int TrainerId { get; set; }
        public int? BranchId { get; set; }

    }
}
