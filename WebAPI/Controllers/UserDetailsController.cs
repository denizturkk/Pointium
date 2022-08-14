using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/user/[controller]")]
    [ApiController]
    public class UserDetailsController : ControllerBase
    {
        private IUserDetailService _userDetailService;
        public UserDetailsController(IUserDetailService userDetailService)
        {
            _userDetailService = userDetailService; 
        }

        [HttpGet("get")]
        public IActionResult Get(int id)
        {
            var result = _userDetailService.Get(id);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }



        [HttpGet("getbyuserid")]
       public IActionResult GetByUserId(int id)
        {
            var result =_userDetailService.GetByUserId(id);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(UserDetail userDetail)
        {
            var result = _userDetailService.Add(userDetail);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(UserDetail userDetail)
        {
            var result = _userDetailService.Add(userDetail);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _userDetailService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


    }
}
