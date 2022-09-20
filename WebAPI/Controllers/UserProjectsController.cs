using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProjectsController : ControllerBase
    {
        private IUserProjectService _userProjectService;
        public UserProjectsController(IUserProjectService userProjectService )
        {
            _userProjectService = userProjectService;
        }


        [HttpPost("add")]
        public IActionResult Add(UserProject userProject)
        {
            var result = _userProjectService.Add(userProject);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }
       
        [HttpDelete("delete")]
        public IActionResult Delete(UserProject userProject)
        {
            var result = _userProjectService.Delete(userProject);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(UserProject userProject)
        {
            var result = _userProjectService.Update(userProject);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);

        }

        [HttpGet("getbyuserid")]
        public IActionResult GetByUserId(int userId)
        {
           //data result dondurmeli?????
            var result = _userProjectService.GetAllWithDetailsByUserId(userId);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);

        }

    }
}
