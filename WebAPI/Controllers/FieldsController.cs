using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FieldsController : ControllerBase
    {
        IFieldService _fieldService;
        public FieldsController(IFieldService fieldService)
        {
            _fieldService = fieldService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _fieldService.GetAll();
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);

        }

        [HttpPost("update")]
        public IActionResult Update(Field field)
        {
            var result = _fieldService.Update(field);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);

        }

        [HttpPost("add")]
        public IActionResult Add(Field field)
        {
            var result = _fieldService.Add(field);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }


        [HttpDelete("delete")]
        public IActionResult Delete(Field field)
        {
            var result = _fieldService.Delete(field);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }


        [HttpGet("get")]
        public IActionResult Get(int id)
        {
            var result = _fieldService.Get(id);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }
    }
}
