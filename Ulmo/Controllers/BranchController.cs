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
    public class BranchsController : ControllerBase
    {
        private readonly IBranchService _BranchService;
        private readonly IMapper _mapper;
        private readonly DatabaseContext _context;

        public BranchsController(IBranchService BranchService, IMapper mapper, DatabaseContext context)
        {
            this._mapper = mapper;
            this._BranchService = BranchService;
            this._context = context;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<BranchDto>>> GetAllBranchs()
        {
            var Branchs = await _BranchService.GetAllBranchs();
            var BranchResources = _mapper.Map<IEnumerable<Branch>, IEnumerable<BranchDto>>(Branchs);

            return Ok(BranchResources);
        }
        [HttpGet("GetAllBranches")]
        public async Task<ActionResult<IEnumerable<BranchDto>>> GetAllBranches()
        {
            var Branchs = await _BranchService.GetAllBranchs();
            var BranchLocations = Branchs.ToList();

            return Ok(BranchLocations);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BranchDto>> GetBranchById(int id)
        {
            var Branch = await _BranchService.GetBranchById(id);
            var BranchResource = _mapper.Map<Branch, BranchDto>(Branch);

            return Ok(BranchResource);
        }


        //[HttpPost("")]
        //public async Task<ActionResult<BranchDto>> CreateBranch([FromBody] CreateBranchDto saveBranchResource)
        //{
        //    var validator = new CreateBranchResourceValidator();
        //    var validationResult = await validator.ValidateAsync(saveBranchResource);

        //    if (!validationResult.IsValid)
        //        return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

        //    var BranchToCreate = _mapper.Map<CreateBranchDto, Branch>(saveBranchResource);

        //    var newBranch = await _BranchService.CreateBranch(BranchToCreate);

        //    var Branch = await _BranchService.GetBranchById(newBranch.Id);

        //    var BranchResource = _mapper.Map<Branch, BranchDto>(Branch);



        //    return Ok(BranchResource);
        //}

        //[HttpPost("{id}")]
        //public async Task<ActionResult<BranchDto>> UpdateBranch(int id, [FromBody] SaveBranchDto saveBranchResource)
        //{
        //    var validator = new SaveBranchResourceValidator();
        //    var validationResult = await validator.ValidateAsync(saveBranchResource);

        //    if (!validationResult.IsValid)
        //        return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

        //    var BranchToBeUpdated = await _BranchService.GetBranchById(id);

        //    if (BranchToBeUpdated == null)
        //        return NotFound();

        //    var Branch = _mapper.Map<SaveBranchDto, Branch>(saveBranchResource);

        //    await _BranchService.UpdateBranch(BranchToBeUpdated, Branch);

        //    var updatedBranch = await _BranchService.GetBranchById(id);

        //    var updatedBranchResource = _mapper.Map<Branch, BranchDto>(updatedBranch);

        //    return Ok(updatedBranchResource);
        //}
        [HttpPost("{Location}")]
        public async Task<ActionResult<BranchDto>> UpdateBranchLocation(int Id, string Location, [FromBody] BranchDto Branch)
        {
            try
            {
                var branch = await _BranchService.GetBranchById(Id);
                branch.Location = Location;
                await _context.SaveChangesAsync();
                return Ok(branch);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBranch(int id)
        {
            var Branch = await _BranchService.GetBranchById(id);

            await _BranchService.DeleteBranch(Branch);

            return NoContent();
        }
    }
}
