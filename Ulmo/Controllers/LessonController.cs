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
    public class LessonsController : ControllerBase
    {
        private readonly ILessonService _LessonService;
        private readonly IMapper _mapper;
        private readonly DatabaseContext _context;

        public LessonsController(ILessonService LessonService, IMapper mapper, DatabaseContext context)
        {
            this._mapper = mapper;
            this._LessonService = LessonService;
            this._context = context;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<LessonDto>>> GetAllLessons()
        {
            var Lessons =  _LessonService.GetAllLessons();
            var LessonResources = _mapper.Map<IEnumerable<Lesson>, IEnumerable<LessonDto>>(Lessons);

            return Ok(LessonResources);
        }
        [HttpGet("GetAllLessons")]
        public async Task<ActionResult<IEnumerable<LessonDto>>> GetAllLessones()
        {
            var Lessons =  _LessonService.GetAllLessons();
            var LessonLocations = Lessons.ToList();
            LessonLocations= (List<Lesson>)LessonLocations.OrderByDescending(x => x.StartDate);

            return Ok(LessonLocations);
        }

        [HttpGet("GetLessonById")]
        public async Task<ActionResult<LessonDto>> GetLessonById(int id)
        {
            var Lesson = await _LessonService.GetLessonById(id);
            var LessonResource = _mapper.Map<Lesson, LessonDto>(Lesson);
            return Ok(LessonResource);
        }

        [HttpGet("LessonsByBranchName")]
        public async Task<ActionResult<LessonDto>> GetLessonsByBranchName(String branchName)
        {
            
            try
            {   
                var lesson =  _context.Lessons.Where(m => m.Classes.Branch.Name== branchName&& m.StartDate >= DateTime.Now).AsEnumerable();
                var lessons = lesson.ToList();
                var sortedLessons = lesson.OrderByDescending(x => x.StartDate);
                if (sortedLessons is null)
                {
                    return NotFound("There is no active lesson on thi");
                }
                return Ok(sortedLessons);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        //[HttpPost("")]
        //public async Task<ActionResult<LessonDto>> CreateLesson([FromBody] CreateLessonDto saveLessonResource)
        //{
        //    var validator = new CreateLessonResourceValidator();
        //    var validationResult = await validator.ValidateAsync(saveLessonResource);

        //    if (!validationResult.IsValid)
        //        return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

        //    var LessonToCreate = _mapper.Map<CreateLessonDto, Lesson>(saveLessonResource);

        //    var newLesson = await _LessonService.CreateLesson(LessonToCreate);

        //    var Lesson = await _LessonService.GetLessonById(newLesson.Id);

        //    var LessonResource = _mapper.Map<Lesson, LessonDto>(Lesson);



        //    return Ok(LessonResource);
        //}

        //[HttpPost("{id}")]
        //public async Task<ActionResult<LessonDto>> UpdateLesson(int id, [FromBody] SaveLessonDto saveLessonResource)
        //{
        //    var validator = new SaveLessonResourceValidator();
        //    var validationResult = await validator.ValidateAsync(saveLessonResource);

        //    if (!validationResult.IsValid)
        //        return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

        //    var LessonToBeUpdated = await _LessonService.GetLessonById(id);

        //    if (LessonToBeUpdated == null)
        //        return NotFound();

        //    var Lesson = _mapper.Map<SaveLessonDto, Lesson>(saveLessonResource);

        //    await _LessonService.UpdateLesson(LessonToBeUpdated, Lesson);

        //    var updatedLesson = await _LessonService.GetLessonById(id);

        //    var updatedLessonResource = _mapper.Map<Lesson, LessonDto>(updatedLesson);

        //    return Ok(updatedLessonResource);
        //}
        [HttpPost("{Description}")]
        public async Task<ActionResult<LessonDto>> UpdateLesson(int Id, string Description, [FromBody] LessonDto Lesson)
        {
            try
            {
                var lesson = await _LessonService.GetLessonById(Id);
                lesson.Description = Description;
                await _context.SaveChangesAsync();
                return Ok(lesson);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLesson(int id)
        {
            var Lesson = await _LessonService.GetLessonById(id);

            await _LessonService.DeleteLesson(Lesson);

            return NoContent();
        }
    }
}
