using Business.Abstract;
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


        //[HttpGet("getmonthly")]
        //public IActionResult GetByUserId(int userProjectId,string mounthId)
        //{
        //    var result = _userProjectDayService.getMonthly(userProjectId, mounthId);
        //    if (result.Success)
        //    {
        //        return Ok(result);

        //    }
        //    return BadRequest(result);


        //}

    } 
}
