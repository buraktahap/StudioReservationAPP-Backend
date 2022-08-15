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
    public class TrainersController : ControllerBase
    {
        private readonly ITrainerService _TrainerService;
        private readonly IMapper _mapper;
        private readonly DatabaseContext _context;

        public TrainersController(ITrainerService TrainerService, IMapper mapper, DatabaseContext context)
        {
            this._mapper = mapper;
            this._TrainerService = TrainerService;
            this._context = context;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<TrainerDto>>> GetAllTrainers()
        {
            var Trainers = await _TrainerService.GetAllTrainers();
            var TrainerResources = _mapper.Map<IEnumerable<Trainer>, IEnumerable<TrainerDto>>(Trainers);

            return Ok(TrainerResources);
        }

        [HttpGet("{id}/getById")]
        public async Task<ActionResult<TrainerDto>> GetTrainerById(int id)
        {
            var Trainer = await _TrainerService.GetTrainerById(id);
            var TrainerResource = _mapper.Map<Trainer, TrainerDto>(Trainer);

            return Ok(TrainerResource);
        }


        //[HttpPost("")]
        //public async Task<ActionResult<TrainerDto>> CreateTrainer([FromBody] CreateTrainerDto saveTrainerResource)
        //{
        //    var validator = new CreateTrainerResourceValidator();
        //    var validationResult = await validator.ValidateAsync(saveTrainerResource);

        //    if (!validationResult.IsValid)
        //        return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

        //    var TrainerToCreate = _mapper.Map<CreateTrainerDto, Trainer>(saveTrainerResource);

        //    var newTrainer = await _TrainerService.CreateTrainer(TrainerToCreate);

        //    var Trainer = await _TrainerService.GetTrainerById(newTrainer.Id);

        //    var TrainerResource = _mapper.Map<Trainer, TrainerDto>(Trainer);



        //    return Ok(TrainerResource);
        //}

        //[HttpPost("{id}/nameUpdate")]
        //public async Task<ActionResult<TrainerDto>> UpdateTrainer(int id, [FromBody] TrainerDto trainerDto)
        //{
        //    var validator = new SaveTrainerResourceValidator();
        //    var validationResult = await validator.ValidateAsync(saveTrainerResource);

        //    if (!validationResult.IsValid)
        //        return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

        //    var TrainerToBeUpdated = await _TrainerService.GetTrainerById(id);

        //    if (TrainerToBeUpdated == null)
        //        return NotFound();

        //    var Trainer = _mapper.Map<SaveTrainerDto, Trainer>(saveTrainerResource);

        //    await _TrainerService.UpdateTrainer(TrainerToBeUpdated, Trainer);

        //    var updatedTrainer = await _TrainerService.GetTrainerById(id);

        //    var updatedTrainerResource = _mapper.Map<Trainer, TrainerDto>(updatedTrainer);

        //    return Ok(updatedTrainerResource);
        //}
        //[HttpPost("{Location}/locationUpdate")]
        //public async Task<ActionResult<TrainerLocationDto>> UpdateTrainerLocation(int Id, string Location, [FromBody] TrainerLocationDto Trainer)
        //{
        //    try
        //    {
        //        var Trainer = await _TrainerService.GetTrainerById(Id);
        //        Trainer.Location = Location;
        //        await _context.SaveChangesAsync();
        //        return Ok(Trainer);

        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(e.Message);
        //    }
        //}

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrainer(int id)
        {
            var Trainer = await _TrainerService.GetTrainerById(id);

            await _TrainerService.DeleteTrainer(Trainer);

            return NoContent();
        }
    }
}
