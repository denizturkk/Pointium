using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProjectDaysController : ControllerBase
    {
        private IUserProjectDayService _userProjectDayService;
        public UserProjectDaysController(IUserProjectDayService userProjectDayService)
        {
            _userProjectDayService = userProjectDayService;
        }

        [HttpPost("add")]
        public IActionResult Add(UserProjectDay userProjectDay)
        {
            var result = _userProjectDayService.Add(userProjectDay);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(UserProjectDay userProjectDay)
        {
            var result = _userProjectDayService.Update(userProjectDay);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }

        [HttpGet("getmonthly")]
        public IActionResult GetMonthly(int userProjectId,int userId ,int year,byte month)
        {
            var result = _userProjectDayService.GetMonthly(userProjectId,userId, year,month);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);

        }




    }
}
