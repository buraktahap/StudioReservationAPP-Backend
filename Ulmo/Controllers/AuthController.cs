
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using StudioReservationAPP.Core.EFContext;
using StudioReservationAPP.Core.Entities;
using StudioReservationAPP.Models;
using StudioReservationAPP.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly DatabaseContext _context;
        private readonly SignInManager<Member> _signManager;
        private readonly IMapper _mapper;

        public AuthController(DatabaseContext context, IMapper mapper,  IMemberService MemberService)
        {
            _context = context;
            _mapper = mapper;
        }



        //[HttpPost("EditMember")]
        //public async Task<IActionResult> EditMember([FromBody] UpdateMemberDTO saveMemberResource, string MemberEmail)
        //{
        //    var MemberToBeUpdated = await _MemberManager.FindByEmailAsync(MemberEmail);
        //    if (MemberToBeUpdated == null)
        //        return StatusCode(StatusCodes.Status404NotFound, new Response { Status = "Error", Message = "Member does not exists!" });

        //    var Member = _mapper.Map<UpdateMemberDTO, Member>(saveMemberResource);
        //    await _MemberService.UpdateMember(MemberToBeUpdated, Member);
        //    var updatedMember = await _MemberManager.FindByEmailAsync(MemberEmail);
        //    var updatedMemberResource = _mapper.Map<Member, UpdateMemberDTO>(updatedMember);
        //    return Ok(updatedMemberResource);
        //}

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(MemberLoginDto MemberLoginDto)
        {
            try
            {
                var member = _context.Members.Where(m => m.Email == MemberLoginDto.Email && m.Password == MemberLoginDto.Password).FirstOrDefault();
                if (member is null)
                {
                    return NotFound("Member not found");
                }
                return Ok(member);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            await _signManager.SignOutAsync();
            return Ok(new Response { Status = "Success", Message = "Logout success!" });
        }



        //[HttpPost("Member/{MemberEmail}/Role")]
        //public async Task<IActionResult> AddMemberToRole(string MemberEmail, [FromBody] string roleName)
        //{
        //    var Member = _MemberManager.Members.SingleOrDefault(u => u.MemberName == MemberEmail);
        //    var result = await _MemberManager.AddToRoleAsync(Member, roleName);

        //    if (result.Succeeded)
        //    {
        //        return Ok();
        //    }

        //    return Problem(result.Errors.First().Description, null, 500);
        //}

        //[HttpPost("ResetPasswordToken")]
        //public async Task<IActionResult> ResetPasswordToken([FromBody] ResetPasswordTokenDTO model)
        //{
        //    var Member = await _MemberManager.FindByEmailAsync(model.Email);
        //    if (Member == null)
        //    {
        //        return StatusCode(StatusCodes.Status404NotFound, new Response { Status = "Error", Message = "Member does not exists!" });
        //    }

        //    var token = await _MemberManager.GeneratePasswordResetTokenAsync(Member);
        //    return Ok(new { token = token });
        //}

        //[HttpPost("ResetPasswordMember")]
        //public async Task<IActionResult> ResetPasswordMember([FromBody] ResetPasswordDTO model)
        //{
        //    var Member = await _MemberManager.FindByEmailAsync(model.Email);
        //    if (Member == null)
        //    {
        //        return StatusCode(StatusCodes.Status404NotFound);
        //    }

        //    if (string.Compare(model.NewPassword, model.ConfirmNewPassword) != 0)
        //    {
        //        return StatusCode(StatusCodes.Status400BadRequest, new Response { Status = "Error", Message = "The new password and confirm new password does not match!" });
        //    }

        //    if (string.IsNullOrEmpty(model.Token))
        //    {
        //        return StatusCode(StatusCodes.Status400BadRequest, new Response { Status = "Error", Message = "Invalid Token!" });
        //    }

        //    var result = await _MemberManager.ResetPasswordAsync(Member, model.Token, model.NewPassword);
        //    if (!result.Succeeded)
        //    {
        //        var errors = new List<string>();

        //        foreach (var error in result.Errors)
        //        {
        //            errors.Add(error.Description);
        //        }

        //        return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = String.Join(",", errors) });
        //    }

        //    return Ok(new Response { Status = "Success", Message = "Password Reseted Successfully!" });
        //}

    }
}