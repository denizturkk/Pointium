using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobTitlesController : ControllerBase
    {
        IJobTitleService _jobTitleService;
        public JobTitlesController(IJobTitleService jobTitleService)
        {
            _jobTitleService = jobTitleService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _jobTitleService.GetAll();
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);

        }

        [HttpPost("update")]
        public IActionResult Update(JobTitle jobTitle)
        {
            var result = _jobTitleService.Update(jobTitle);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);

        }

        [HttpPost("add")]
        public IActionResult Add(JobTitle jobTitle)
        {
            var result = _jobTitleService.Add(jobTitle);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }


        [HttpDelete("delete")]
        public IActionResult Delete(JobTitle jobTitle)
        {
            var result = _jobTitleService.Delete(jobTitle);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }


        [HttpGet("get")]
        public IActionResult Get(int id)
        {
            var result = _jobTitleService.Get(id);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }


    }
}
