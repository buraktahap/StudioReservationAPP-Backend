using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using StudioReservationAPP.Core.EFContext;
using StudioReservationAPP.Core.Entities;
using StudioReservationAPP.Models;
using StudioReservationAPP.Services;
using StudioReservationAPP.Validator;

namespace StudioReservationAPP.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class TrainerWorkPlacesController : ControllerBase
    {
        private readonly ITrainerWorkPlaceService _TrainerWorkPlaceService;
        private readonly IMapper _mapper;
        private readonly DatabaseContext _context;

        public TrainerWorkPlacesController(ITrainerWorkPlaceService TrainerWorkPlaceService, IMapper mapper, DatabaseContext context)
        {
            this._mapper = mapper;
            this._TrainerWorkPlaceService = TrainerWorkPlaceService;
            this._context = context;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<TrainerWorkPlaceDto>>> GetAllTrainerWorkPlaces()
        {
            var TrainerWorkPlaces = await _TrainerWorkPlaceService.GetAllTrainerWorkPlaces();
            var TrainerWorkPlaceResources = _mapper.Map<IEnumerable<TrainerWorkPlace>, IEnumerable<TrainerWorkPlaceDto>>(TrainerWorkPlaces);

            return Ok(TrainerWorkPlaceResources);
        }

        [HttpGet("{id}/getById")]
        public async Task<ActionResult<TrainerWorkPlaceDto>> GetTrainerWorkPlaceById(int id)
        {
            var TrainerWorkPlace = await _TrainerWorkPlaceService.GetTrainerWorkPlaceById(id);
            var TrainerWorkPlaceResource = _mapper.Map<TrainerWorkPlace, TrainerWorkPlaceDto>(TrainerWorkPlace);

            return Ok(TrainerWorkPlaceResource);
        }


        //[HttpPost("")]
        //public async Task<ActionResult<TrainerWorkPlaceDto>> CreateTrainerWorkPlace([FromBody] CreateTrainerWorkPlaceDto saveTrainerWorkPlaceResource)
        //{
        //    var validator = new CreateTrainerWorkPlaceResourceValidator();
        //    var validationResult = await validator.ValidateAsync(saveTrainerWorkPlaceResource);

        //    if (!validationResult.IsValid)
        //        return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

        //    var TrainerWorkPlaceToCreate = _mapper.Map<CreateTrainerWorkPlaceDto, TrainerWorkPlace>(saveTrainerWorkPlaceResource);

        //    var newTrainerWorkPlace = await _TrainerWorkPlaceService.CreateTrainerWorkPlace(TrainerWorkPlaceToCreate);

        //    var TrainerWorkPlace = await _TrainerWorkPlaceService.GetTrainerWorkPlaceById(newTrainerWorkPlace.Id);

        //    var TrainerWorkPlaceResource = _mapper.Map<TrainerWorkPlace, TrainerWorkPlaceDto>(TrainerWorkPlace);



        //    return Ok(TrainerWorkPlaceResource);
        //}

        //[HttpPost("{id}/nameUpdate")]
        //public async Task<ActionResult<TrainerWorkPlaceDto>> UpdateTrainerWorkPlace(int id, [FromBody] TrainerWorkPlaceDto TrainerWorkPlaceDto)
        //{
        //    var validator = new SaveTrainerWorkPlaceResourceValidator();
        //    var validationResult = await validator.ValidateAsync(saveTrainerWorkPlaceResource);

        //    if (!validationResult.IsValid)
        //        return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

        //    var TrainerWorkPlaceToBeUpdated = await _TrainerWorkPlaceService.GetTrainerWorkPlaceById(id);

        //    if (TrainerWorkPlaceToBeUpdated == null)
        //        return NotFound();

        //    var TrainerWorkPlace = _mapper.Map<SaveTrainerWorkPlaceDto, TrainerWorkPlace>(saveTrainerWorkPlaceResource);

        //    await _TrainerWorkPlaceService.UpdateTrainerWorkPlace(TrainerWorkPlaceToBeUpdated, TrainerWorkPlace);

        //    var updatedTrainerWorkPlace = await _TrainerWorkPlaceService.GetTrainerWorkPlaceById(id);

        //    var updatedTrainerWorkPlaceResource = _mapper.Map<TrainerWorkPlace, TrainerWorkPlaceDto>(updatedTrainerWorkPlace);

        //    return Ok(updatedTrainerWorkPlaceResource);
        //}
        //[HttpPost("{Location}/locationUpdate")]
        //public async Task<ActionResult<TrainerWorkPlaceLocationDto>> UpdateTrainerWorkPlaceLocation(int Id, string Location, [FromBody] TrainerWorkPlaceLocationDto TrainerWorkPlace)
        //{
        //    try
        //    {
        //        var TrainerWorkPlace = await _TrainerWorkPlaceService.GetTrainerWorkPlaceById(Id);
        //        TrainerWorkPlace.Location = Location;
        //        await _context.SaveChangesAsync();
        //        return Ok(TrainerWorkPlace);

        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(e.Message);
        //    }
        //}

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrainerWorkPlace(int id)
        {
            var TrainerWorkPlace = await _TrainerWorkPlaceService.GetTrainerWorkPlaceById(id);

            await _TrainerWorkPlaceService.DeleteTrainerWorkPlace(TrainerWorkPlace);

            return NoContent();
        }
    }
}
