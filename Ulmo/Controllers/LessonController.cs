using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudioReservationAPP.Core.EFContext;
using StudioReservationAPP.Core.Entities;
using StudioReservationAPP.Core.Entities.Enums;
using StudioReservationAPP.Models;
using StudioReservationAPP.Services;
using StudioReservationAPP.Validator;

namespace StudioReservationAPP.Controllers
{


    [Route("api/[controller]/[action]")]
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

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<LessonDto>>> GetAllLessons()
        //{
        //    var Lessons =  _LessonService.GetAllLessons();
        //    var LessonResources = _mapper.Map<IEnumerable<Lesson>, IEnumerable<LessonDto>>(Lessons);

        //    return Ok(LessonResources);
        //}
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LessonDto>>> GetAllLessons()
        {
            var Lessons = _LessonService.GetAllLessons();
            var LessonLocations = Lessons.ToList();
            LessonLocations = (List<Lesson>)LessonLocations.OrderByDescending(x => x.StartDate);

            return Ok(LessonLocations);
        }

        [HttpGet]
        public async Task<ActionResult<LessonDto>> GetLessonById(int id)
        {
            var Lesson = _context.Lessons.Include(x => x.Trainer)
                .Include(q => q.Classes).ThenInclude(b => b.Branch)
                .Where(l => l.Id == id).FirstOrDefault();
            var LessonResource = _mapper.Map<Lesson, LessonDto>(Lesson);
            return Ok(LessonResource);
        }

        [HttpPost]
        public async Task<ActionResult<LessonDto>> GetLessonsByBranchNameAndLessonLevel(int memberId, string branchName, int lessonLevel)
        {
            try
            {
                List<LessonDto> lesson;

                if (lessonLevel == 3)
                {
                     var lessons = _context.Lessons
                    .Include(i => i.MemberLessons).ThenInclude(i => i.Member)
                    .Where(m => m.Classes.Branch.Name == branchName && m.StartDate >= DateTime.Now)
                    .OrderBy(x => x.StartDate)
                    .Select(p => new LessonDto
                    {
                        IsEnrolled = p.MemberLessons.Any(r => r.MemberId == memberId && r.IsEnrolled == true),
                        Id = p.Id,
                        Name = p.Name,
                        Description = p.Description,
                        EstimatedTime = p.EstimatedTime,
                        LessonLevel = p.LessonLevel,
                        LessonType = p.LessonType,
                        EnrollQuota = p.EnrollQuota,
                        StartDate = p.StartDate,
                        EnrollCount = p.EnrollCount,
                        WaitingQueueCount = p.WaitingQueueCount,
                        WaitingQueueQuota = p.WaitingQueueQuota,
                        Rate = p.Rate,
                    }).ToList();
                    lesson = lessons;
                }
                else
                {
                    var lessons = _context.Lessons
                        .Include(i => i.MemberLessons).ThenInclude(i => i.Member)
                        .Where(m => m.Classes.Branch.Name == branchName && (int)m.LessonLevel == lessonLevel && m.StartDate >= DateTime.Now)
                        .OrderBy(x => x.StartDate)
                        .Select(p => new LessonDto
                        {
                            IsEnrolled = p.MemberLessons.Any(r => r.MemberId == memberId && r.IsEnrolled == true),
                            Id = p.Id,
                            Name = p.Name,
                            Description = p.Description,
                            EstimatedTime = p.EstimatedTime,
                            LessonLevel = p.LessonLevel,
                            LessonType = p.LessonType,
                            EnrollQuota = p.EnrollQuota,
                            StartDate = p.StartDate,
                            EnrollCount = p.EnrollCount,
                            WaitingQueueCount = p.WaitingQueueCount,
                            WaitingQueueQuota = p.WaitingQueueQuota,
                            Rate = p.Rate,
                        }).ToList();
                    lesson = lessons;
                }


                if (lesson.Count == 0)
                {
                    return NotFound("There is no active lesson on thiz");
                }
                return Ok(lesson);

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
        [HttpPost]
        public async Task<ActionResult<LessonDto>> UpdateLesson(LessonDto lessonDto)
        {
            try
            {
                var lesson = await _LessonService.GetLessonById(lessonDto.Id);
                lesson.Description = lessonDto.Description;
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
