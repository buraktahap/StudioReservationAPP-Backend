﻿using AutoMapper;
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
    public class MemberLessonsController : ControllerBase
    {
        private readonly IMemberLessonService _MemberLessonService;
        private readonly ILessonService _lessonService;
        private readonly IMapper _mapper;
        private readonly DatabaseContext _context;

        public int MemberLessons { get; private set; }

        public MemberLessonsController(IMemberLessonService MemberLessonService,ILessonService LessonService, IMapper mapper, DatabaseContext context)
        {
            _mapper = mapper;
            _MemberLessonService = MemberLessonService;
            _lessonService = LessonService;
            _context = context;
        }

        [HttpGet("")]
        public async Task<ActionResult<MemberLessonDto>> GetAllMemberLessons()
        {
            var memberLesson =  _MemberLessonService.GetAllMemberLessons();
            

            return Ok(memberLesson);
        }
        [HttpGet("GetAllMemberLessons")]
        public async Task<ActionResult<IEnumerable<MemberLessonDto>>> GetAllMemberLessones()
        {
            var MemberLessons =  _MemberLessonService.GetAllMemberLessons();
            var MemberLessonLocations = MemberLessons.ToList();

            return Ok(MemberLessonLocations);
        }
        //[HttpPost("Enroll")]
        //public async Task<ActionResult<MemberLessonDto>> Enroll(int memberId,int lessonId)
        //{
        //    try
        //    {
        //        var Member = _context.Members.Where(m => m.Id == memberId);
        //        var Lesson = _context.Lessons.Where(m => m.Id == lessonId);
        //        var MemberLesson = new MemberLesson()
        //        var MemberLessons = MemberLesson.ToList();
        //        if (MemberLessons is null)
        //        {
        //            return NotFound("There is no active MemberLesson on this");
        //        }
        //        return Ok(MemberLessons);

        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(e.Message);
        //    }
        //}
        [HttpGet("{id}")]
        public async Task<ActionResult<MemberLessonDto>> GetMemberLessonById(int id)
        {
            try
            {
                var MemberLesson = _context.MemberLessons.Where(ml => ml.Id == id).AsQueryable();
                var MemberLessons = MemberLesson.ToList();
                if (MemberLessons is null)
                {
                    return NotFound("There is no active MemberLesson on this");
                }
                return Ok(MemberLessons);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("GetMemberLessonByLessonId")]
        public async Task<ActionResult<MemberLessonDto>> GetMemberLessonsByLessonId(int id)
        {
            try
            {
                var MemberLesson = _context.MemberLessons.Where(ml => ml.Lesson.Id == id).AsQueryable();
                var MemberLessons = MemberLesson.ToList();
                if (MemberLessons is null)
                {
                    return NotFound("There is no active MemberLesson on this");
                }
                return Ok(MemberLessons);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("MemberLessonsByMemberId")]
        public async Task<ActionResult<MemberLessonDto>> GetMemberLessonsByMemberId(int id)
        {
            try
            {
                var MemberLesson = _context.MemberLessons.Where(ml => ml.Member.Id == id).AsQueryable();
                var MemberLessons = MemberLesson.ToList();
                if (MemberLessons is null)
                {
                    return NotFound("There is no active MemberLesson on this");
                }
                return Ok(MemberLessons);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("LessonsByBranchName")]
        public async Task<ActionResult<MemberLessonDto>> GetLessonsByBranchName(String branchName)
        {

            try
            {
                var memberLesson = _context.MemberLessons.Where(m => m.Lesson.Classes.Branch.Name == branchName && m.Lesson.StartDate >= DateTime.Now).AsQueryable();
                var sortedLessons = memberLesson.OrderBy(x => x.Lesson.StartDate);
                if (sortedLessons == null)
                {
                    return NotFound("There is nothing to checkin");
                }
                else
                {foreach (MemberLesson i in sortedLessons)
                {
                    var lesson = await _lessonService.GetLessonById(i.LessonId);
                    i.Lesson = lesson;
                }
                    return Ok(sortedLessons);
                }

                return NotFound("There is no active reservation.");

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("ReservationList")]
        public async Task<ActionResult<MemberLessonDto>> ReservationList(int id)
        {
            try
            {

                var memberLessons = _context.MemberLessons.AsQueryable()
                    .Where(ml => ml.MemberId == id && ml.isEnrolled == true && ml.Lesson.StartDate >= DateTime.Now)
                    .OrderBy(x => x.Lesson.StartDate);
                //var memberlessons = _context.MemberLessons.AsQueryable().Where(ml => ml.MemberId == id && ml.isEnrolled == true && ml.Lesson.StartDate >= DateTime.Now);
                     

                
                if (memberLessons == null)
                {
                    return NotFound("There is nothing to checkin");
                }
                else
                {foreach (MemberLesson i in memberLessons)
                {
                    var lesson = await _lessonService.GetLessonById(i.LessonId);
                    i.Lesson = lesson;
                }
                    return Ok(memberLessons);
                }

                return NotFound("There is no active reservation.");

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("CheckInLessonDetails")]
        public async Task<ActionResult<MemberLessonDto>> CheckInLessonDetails(int id)
        {
            try
            {

                var memberLessons = _context.MemberLessons
                    .Where(ml => ml.MemberId == id && ml.isEnrolled == true  && ml.Lesson.StartDate >= DateTime.Now)
                    .OrderBy(x => x.Lesson.StartDate)
                    .FirstOrDefault();
               
                //List<LessonDto> reservationLessonList = new List<LessonDto>();
                //foreach (MemberLesson i in MemberLessons)
                //{
                //    var lesson = await _lessonService.GetLessonById(i.LessonId);
                //    var mappedLesson = _mapper.Map<Lesson, LessonDto>(lesson);
                //    reservationLessonList.Add(mappedLesson);
                //}
                //var checkInLesson = reservationLessonList.OrderBy(x => x.StartDate).Where(q=>q.IsCheckIn!=true).First();
                if (memberLessons == null)
                {
                    return NotFound("There is nothing to checkin");
                }else {  
                    memberLessons.Lesson= _context.Lessons.FirstOrDefault(x=>x.Id==memberLessons.LessonId);
                    return Ok(memberLessons);
                }

                return NotFound("There is no active reservation.");

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost("CheckIn")]
        public async Task<ActionResult<MemberLessonDto>> CheckIn(int memberId, int lessonId)
        {
            try
            {
                var lessonToCheckIn = _context.MemberLessons.Where(ml => ml.LessonId == lessonId && ml.MemberId == memberId).FirstOrDefault();
                lessonToCheckIn.isCheckin = true;
                await _context.SaveChangesAsync();
                return Ok("CheckIn is completed!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("EnrollCancel")]
        public async Task<ActionResult<MemberLessonDto>> EnrollCancel([FromBody] MemberLessonDto memberLesson)
        {
            try
            {
                var lessonToCheckIn = _context.MemberLessons.Where(ml => ml.Lesson.Id == memberLesson.lessonId && ml.Member.Id == memberLesson.memberId).FirstOrDefault();
                if (lessonToCheckIn != null)
                {
                    await _MemberLessonService.DeleteMemberLesson(lessonToCheckIn);
                    await _context.SaveChangesAsync();
                    return Ok("Enroll Canceled");
                }
                else return BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("MemberLessonsByLessonName")]
        public async Task<ActionResult<MemberLessonDto>> GetMemberLessonsByLessonName(string lessonName)
        {
            try
            {
                var MemberLesson = _context.MemberLessons.Where(ml => ml.Lesson.Name == lessonName).AsEnumerable();
                var MemberLessons = MemberLesson.ToList();
                if (MemberLessons is null)
                {
                    return NotFound("There is no active MemberLesson on this");
                }
                return Ok(MemberLessons);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPost("Enroll")]
        public async Task<ActionResult<MemberLessonDto>> CreateMemberLesson([FromBody] MemberLessonEnrollDto Enroll)
        {
            try
            {
                
                    var Member = _context.Members.Where(m => m.Id == Enroll.MemberId).FirstOrDefault();
                    var Lesson = _context.Lessons.Where(m => m.Id == Enroll.LessonId).FirstOrDefault();
                    var createMemberLessonDto = new CreateMemberLessonDto();
                    createMemberLessonDto.lesson = Lesson;
                    createMemberLessonDto.member = Member;
                    createMemberLessonDto.isEnrolled = true;

                    var MemberLessonToCreate = _mapper.Map<CreateMemberLessonDto, MemberLesson>(createMemberLessonDto);
                    MemberLessonToCreate.isCheckin = false;
                    var newMemberLesson = await _MemberLessonService.CreateMemberLesson(MemberLessonToCreate);
                    var updatedMemberLessonResource = _mapper.Map<MemberLesson, MemberLessonDto>(newMemberLesson);
                    await _context.SaveChangesAsync();


                    return Ok(updatedMemberLessonResource);
                
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        //[HttpPost("{id}")]
        //public async Task<ActionResult<MemberLessonDto>> UpdateMemberLesson(int id, [FromBody] SaveMemberLessonDto saveMemberLessonResource)
        //{
        //    var validator = new SaveMemberLessonResourceValidator();
        //    var validationResult = await validator.ValidateAsync(saveMemberLessonResource);

        //    if (!validationResult.IsValid)
        //        return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

        //    var MemberLessonToBeUpdated = await _MemberLessonService.GetMemberLessonById(id);

        //    if (MemberLessonToBeUpdated == null)
        //        return NotFound();

        //    var MemberLesson = _mapper.Map<SaveMemberLessonDto, MemberLesson>(saveMemberLessonResource);

        //    await _MemberLessonService.UpdateMemberLesson(MemberLessonToBeUpdated, MemberLesson);

        //    var updatedMemberLesson = await _MemberLessonService.GetMemberLessonById(id);

        //    var updatedMemberLessonResource = _mapper.Map<MemberLesson, MemberLessonDto>(updatedMemberLesson);

        //    return Ok(updatedMemberLessonResource);
        //}
        //[HttpPost("{Description}")]
        //public async Task<ActionResult<MemberLessonDto>> UpdateMemberLesson([FromBody] MemberLessonDto MemberLessonToBeUpdated, MemberLessonDto MemberLesson)
        //{
        //    try
        //    {
        //        var memberLesson = await _MemberLessonService.GetMemberLessonById(MemberLesson.id);
        //        var memberLessonToBeUpdated = await _MemberLessonService.GetMemberLessonById(MemberLessonToBeUpdated.id);
        //        memberLessonToBeUpdated = memberLesson;
        //        await _context.SaveChangesAsync();
        //        return Ok(MemberLesson);

        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(e.Message);
        //    }
        //}

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMemberLesson(int id)
        {
            var MemberLesson = await _MemberLessonService.GetMemberLessonById(id);

            await _MemberLessonService.DeleteMemberLesson(MemberLesson);

            return NoContent();
        }
    }
}
