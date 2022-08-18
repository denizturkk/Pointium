using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        IDepartmentService _deparmentService;
        public DepartmentsController(IDepartmentService deparmentService)
        {
            _deparmentService = deparmentService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _deparmentService.GetAllWithDetails();
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);

        }

        [HttpPost("update")]
        public IActionResult Update(Department department)
        {
            var result = _deparmentService.Update(department);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);

        }

        [HttpPost("add")]
        public IActionResult Add(Department department)
        {
            var result = _deparmentService.Add(department);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }


        [HttpDelete("delete")]
        public IActionResult Delete(Department department)
        {
            var result = _deparmentService.Delete(department);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }


        [HttpGet("get")]
        public IActionResult Get(int id)
        {
            var result = _deparmentService.GetWithDetails(id);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }

    }
}
