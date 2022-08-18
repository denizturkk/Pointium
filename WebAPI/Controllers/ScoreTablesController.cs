using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoreTablesController : ControllerBase
    {
        IScoreTableService _scoreTabelService;
      
        public ScoreTablesController(IScoreTableService scoreTableService)
        {
            _scoreTabelService=scoreTableService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _scoreTabelService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getallabsences")]
        public IActionResult GetAllAbsences()
        {
            var result = _scoreTabelService.GetAllAbsences();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getallworks")]
        public IActionResult GetAllWorks()
        {
            var result = _scoreTabelService.GetAllWorks();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

    }
}
