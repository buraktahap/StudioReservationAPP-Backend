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
    public class ClassController : ControllerBase
    {
        private readonly IClassService _ClassService;
        private readonly IMapper _mapper;
        private readonly DatabaseContext _context;

        public ClassController(IClassService ClassService, IMapper mapper, DatabaseContext context)
        {
            this._mapper = mapper;
            this._ClassService = ClassService;
            this._context = context;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<ClassDto>>> GetAllClasss()
        {
            var Classes = await _ClassService.GetAllClasss();
            var ClassResources = _mapper.Map<IEnumerable<Class>, IEnumerable<ClassDto>>(Classes);

            return Ok(ClassResources);
        }
        [HttpGet("GetAllLocations")]
        public async Task<ActionResult<IEnumerable<CreateClassDto>>> GetAllClassLocations()
        {
            var Classs = await _ClassService.GetAllClasss();
            var ClassLocations = Classs.ToList();

            return Ok(ClassLocations);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClassDto>> GetClassById(int id)
        {
            var Class = await _ClassService.GetClassById(id);
            var ClassResource = _mapper.Map<Class, ClassDto>(Class);

            return Ok(ClassResource);
        }


        //[HttpPost("")]
        //public async Task<ActionResult<ClassDto>> CreateClass([FromBody] CreateClassDto saveClassResource)
        //{
        //    var validator = new CreateClassResourceValidator();
        //    var validationResult = await validator.ValidateAsync(saveClassResource);

        //    if (!validationResult.IsValid)
        //        return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

        //    var ClassToCreate = _mapper.Map<CreateClassDto, Class>(saveClassResource);

        //    var newClass = await _ClassService.CreateClass(ClassToCreate);

        //    var Class = await _ClassService.GetClassById(newClass.Id);

        //    var ClassResource = _mapper.Map<Class, ClassDto>(Class);



        //    return Ok(ClassResource);
        //}

        //[HttpPost("{id}")]
        //public async Task<ActionResult<ClassDto>> UpdateClass(int id, [FromBody] SaveClassDto saveClassResource)
        //{
        //    var validator = new SaveClassResourceValidator();
        //    var validationResult = await validator.ValidateAsync(saveClassResource);

        //    if (!validationResult.IsValid)
        //        return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

        //    var ClassToBeUpdated = await _ClassService.GetClassById(id);

        //    if (ClassToBeUpdated == null)
        //        return NotFound();

        //    var Class = _mapper.Map<SaveClassDto, Class>(saveClassResource);

        //    await _ClassService.UpdateClass(ClassToBeUpdated, Class);

        //    var updatedClass = await _ClassService.GetClassById(id);

        //    var updatedClassResource = _mapper.Map<Class, ClassDto>(updatedClass);

        //    return Ok(updatedClassResource);
        //}
        //[HttpPost("{Location}")]  //isteğe göre yeniden düzenlemesi gerekiyor ama buradan branch bilgisini düzenlemeyi bilmiyorum
        //public async Task<ActionResult<BranchDto>> UpdateClassLocation(int Id, string Location, [FromBody] ClassDto ClassDto, [FromBody] BranchDto BranchDto)
        //{
        //    try
        //    {
        //        var Class = _context.Classes.Where(m => m.Id == ClassDto.Id).FirstOrDefault();
        //        BranchDto.Location = _context.Branches.Where(m => Class.BranchId == BranchDto.Id).FirstOrDefault().Location;
        //        return Ok(Class);

        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(e.Message);
        //    }
        //}

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBranch(int id)
        {
            var Class = await _ClassService.GetClassById(id);

            await _ClassService.DeleteClass(Class);

            return NoContent();
        }
    }
}
