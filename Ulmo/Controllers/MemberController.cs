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
        public class MembersController : ControllerBase
        {
            private readonly IMemberService _MemberService;
            private readonly IMapper _mapper;
            private readonly DatabaseContext _context;

            public MembersController(IMemberService MemberService, IMapper mapper, DatabaseContext context)
            {
                this._mapper = mapper;
                this._MemberService = MemberService;
                this._context = context;
            }

            [HttpGet("")]
            public async Task<ActionResult<IEnumerable<MemberDto>>> GetAllMembers()
            {
                var Members = await _MemberService.GetAllMembers();
                var MemberResources = _mapper.Map<IEnumerable<Member>, IEnumerable<MemberDto>>(Members);

                return Ok(MemberResources);
            }

            [HttpGet("getById")]
            public async Task<ActionResult<MemberDto>> GetMemberById(int id)
            {
                var Member = await _MemberService.GetMemberById(id);
                var MemberResource = _mapper.Map<Member, MemberDto>(Member);

                return Ok(MemberResource);
            }


            //[HttpPost("")]
            //public async Task<ActionResult<MemberDto>> CreateMember([FromBody] CreateMemberDto saveMemberResource)
            //{
            //    var validator = new CreateMemberResourceValidator();
            //    var validationResult = await validator.ValidateAsync(saveMemberResource);

            //    if (!validationResult.IsValid)
            //        return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            //    var MemberToCreate = _mapper.Map<CreateMemberDto, Member>(saveMemberResource);

            //    var newMember = await _MemberService.CreateMember(MemberToCreate);

            //    var Member = await _MemberService.GetMemberById(newMember.Id);

            //    var MemberResource = _mapper.Map<Member, MemberDto>(Member);

                

            //    return Ok(MemberResource);
            //}

            [HttpPost("{id}/nameUpdate")]
            public async Task<ActionResult<MemberDto>> UpdateMember(int id, [FromBody] SaveMemberDto saveMemberResource)
            {
                var validator = new SaveMemberResourceValidator();
                var validationResult = await validator.ValidateAsync(saveMemberResource);

                if (!validationResult.IsValid)
                    return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

                var MemberToBeUpdated = await _MemberService.GetMemberById(id);

                if (MemberToBeUpdated == null)
                    return NotFound();

                var Member = _mapper.Map<SaveMemberDto, Member>(saveMemberResource);

                await _MemberService.UpdateMember(MemberToBeUpdated, Member);

                var updatedMember = await _MemberService.GetMemberById(id);

                var updatedMemberResource = _mapper.Map<Member, MemberDto>(updatedMember);

                return Ok(updatedMemberResource);
            }
            [HttpPost("locationUpdate")]
            public async Task<ActionResult<MemberLocationDto>> UpdateMemberLocation( [FromBody] MemberLocationDto Member)
            {
                try
                {
                    var member = await _MemberService.GetMemberById(Member.Id);
                    member.Location = Member.Location;
                    await _context.SaveChangesAsync();
                    return Ok(member);

                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteMember(int id)
            {
                var Member = await _MemberService.GetMemberById(id);

                await _MemberService.DeleteMember(Member);

                return NoContent();
            }
        }
    }
