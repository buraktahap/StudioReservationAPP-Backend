using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudioReservationAPP.Core.EFContext;
using StudioReservationAPP.Core.Entities;
using StudioReservationAPP.Models;
using StudioReservationAPP.Services;
using StudioReservationAPP.Validator;

namespace StudioReservationAPP.Controllers
{


    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WaitingQueuesController : ControllerBase
    {
        private readonly IWaitingQueueService _WaitingQueueService;
        private readonly IMapper _mapper;
        private readonly DatabaseContext _context;
        private readonly ILessonService _lessonService;
        public WaitingQueuesController(IWaitingQueueService WaitingQueueService, IMapper mapper, DatabaseContext context)
        {
            this._mapper = mapper;
            this._WaitingQueueService = WaitingQueueService;
            this._context = context;
        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<WaitingQueueDto>>> GetAllWaitingQueues()
        //{
        //    var WaitingQueues =  _WaitingQueueService.GetAllWaitingQueues();
        //    var WaitingQueueResources = _mapper.Map<IEnumerable<WaitingQueue>, IEnumerable<WaitingQueueDto>>(WaitingQueues);

        //    return Ok(WaitingQueueResources);
        //}
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WaitingQueueDto>>> GetAllWaitingQueues()
        {
            var WaitingQueues = _WaitingQueueService.GetAllWaitingQueues();
            var WaitingQueueLocations = WaitingQueues.ToList();
            WaitingQueueLocations = (List<WaitingQueue>)WaitingQueueLocations.OrderByDescending(x => x.QueueEnrollTime);

            return Ok(WaitingQueueLocations);
        }

        [HttpGet]
        public async Task<ActionResult<WaitingQueueDto>> GetWaitingQueueById(int id)
        {
            var WaitingQueue = await _WaitingQueueService.GetWaitingQueueById(id);
            var WaitingQueueResource = _mapper.Map<WaitingQueue, WaitingQueueDto>(WaitingQueue);
            return Ok(WaitingQueueResource);
        }

        [HttpGet]
        public async Task<ActionResult<WaitingQueueDto>> GetWaitingQueueByLessonId(int lessonId)
        {
            var WaitingQueue =  _context.WaitingQueues.Where(x=>x.LessonId==lessonId).AsQueryable().ToList();
            return Ok(WaitingQueue);
        }
        [HttpGet]
        public async Task<ActionResult<WaitingQueueDto>> GetFirstWaitingQueueObject(int lessonId)
        {
            var WaitingQueue = _context.WaitingQueues.Where(x => x.LessonId == lessonId).AsQueryable().ToList();
            return Ok(WaitingQueue.FirstOrDefault());
        }


        //[HttpPost]
        //public async Task<ActionResult<WaitingQueueDto>> GetWaitingQueuesByBranchName(int lessonId)
        //{
        //    try
        //    {
        //        var WaitingQueues = _context.Lessons
        //            .Include(i => i.WaitingQueues).ThenInclude(i => i.Member)
        //            .Where(m => m.Id== lessonId && m.StartDate >= DateTime.Now)
        //            .OrderBy(x => x.StartDate)
        //            .Select(p => new WaitingQueueDto
        //            {
        //                IsEnrolled = p.MemberWaitingQueues.Any(r => r.MemberId == memberId && r.IsEnrolled == true),
        //                Id = p.Id,
        //                Name = p.Name,
        //                Description = p.Description,
        //                EstimatedTime = p.EstimatedTime,
        //                WaitingQueueLevel = p.WaitingQueueLevel,
        //                WaitingQueueType = p.WaitingQueueType,
        //                Quota = p.Quota,
        //                StartDate = p.StartDate,
        //            }).ToList();

        //        if (WaitingQueues.Count == 0)
        //        {
        //            return NotFound("There is no active WaitingQueue on thi");
        //        }
        //        return Ok(WaitingQueues);

        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(e.Message);
        //    }
        //}


        //[HttpPost("Enroll")]
        //public async Task<ActionResult<WaitingQueue>> CreateWaitingQueue([FromBody] CreateWaitingQueueIdDto waitingQueueDto)
        //{
        //    try
        //    {
        //        var createWaitingQueueDto = new CreateWaitingQueueDto
        //        {
        //            lesson = _context.Lessons.Where(m => m.Id == waitingQueueDto.LessonId).FirstOrDefault(),
        //            member = _context.Members.Where(m => m.Id == waitingQueueDto.MemberId).FirstOrDefault(),
        //            QueueEnrollTime = DateTime.Now
        //        };
        //        if(createWaitingQueueDto != null && createWaitingQueueDto.lesson.WaitingQueueCount<5)
        //        {
        //        var waitingQueue = _mapper.Map<CreateWaitingQueueDto, WaitingQueue>(createWaitingQueueDto);
        //        var newWaitingQueue = await _WaitingQueueService.CreateWaitingQueue(waitingQueue);
        //        newWaitingQueue.Lesson.WaitingQueueCount++;
        //        await _context.SaveChangesAsync();
        //        return Ok(newWaitingQueue); 
        //        }
        //        else
        //        {
        //            return BadRequest();
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        return NotFound(e.Message);
        //    }

        //}

        //[HttpPost("{id}")]
        //public async Task<ActionResult<WaitingQueueDto>> UpdateWaitingQueue(int id, [FromBody] SaveWaitingQueueDto saveWaitingQueueResource)
        //{
        //    var validator = new SaveWaitingQueueResourceValidator();
        //    var validationResult = await validator.ValidateAsync(saveWaitingQueueResource);

        //    if (!validationResult.IsValid)
        //        return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

        //    var WaitingQueueToBeUpdated = await _WaitingQueueService.GetWaitingQueueById(id);

        //    if (WaitingQueueToBeUpdated == null)
        //        return NotFound();

        //    var WaitingQueue = _mapper.Map<SaveWaitingQueueDto, WaitingQueue>(saveWaitingQueueResource);

        //    await _WaitingQueueService.UpdateWaitingQueue(WaitingQueueToBeUpdated, WaitingQueue);

        //    var updatedWaitingQueue = await _WaitingQueueService.GetWaitingQueueById(id);

        //    var updatedWaitingQueueResource = _mapper.Map<WaitingQueue, WaitingQueueDto>(updatedWaitingQueue);

        //    return Ok(updatedWaitingQueueResource);
        //}
        [HttpPost]
        public async Task<ActionResult<WaitingQueueDto>> UpdateWaitingQueue(WaitingQueueDto WaitingQueueDto)
        {
            try
            {
                var WaitingQueue = await _WaitingQueueService.GetWaitingQueueById(WaitingQueueDto.Id);
                WaitingQueue.Lesson.Name = WaitingQueueDto.Lesson.Name;
                await _context.SaveChangesAsync();
                return Ok(WaitingQueue);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWaitingQueue(int id)
        {
            var WaitingQueue = await _WaitingQueueService.GetWaitingQueueById(id);

            await _WaitingQueueService.DeleteWaitingQueue(WaitingQueue);

            return NoContent();
        }
    }
}
