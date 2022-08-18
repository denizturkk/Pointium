using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        private IUserDetailService _userDetailService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _userService.GetAllWithDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("getbyemail")]
        public IActionResult GetByUserId(string email)
        {
            var result = _userService.GetWithDetailsByEmail(email);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


         [HttpGet("getbyuserid")]
         public IActionResult GetByUserId(int userId)
           {
               var result = _userService.GetWithDetailsByUserId(userId);
               if (result.Success)
               {
                    return Ok(result);

               }
              return BadRequest(result);
         }

        [HttpPost("adduserdetails")]
         public IActionResult AddUserDetails(UserDetail userDetail)
        {
            var result = _userDetailService.Add(userDetail);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }


    }
}
