using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {

        private IProjectService _projectService;

        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        //tested
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _projectService.GetAllWithDetails();
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);

        }
        //tested
        [HttpGet("getbyleadbyid")]
        public  IActionResult GetByLeader(int leadById)
        {
            var result = _projectService.GetAllWithDetailsByLeadId(leadById);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpGet("getallusersbyprojectid")]
        public IActionResult GetByProjectId(int projectId)
        {
            var result = _projectService.GetAllUsersByProjectId(projectId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        //tested
        [HttpPost("add")]
        public IActionResult Add (Project project )
        {
            var result = _projectService.Add(project);
            
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        //tested
        [HttpDelete("delete")]
        public IActionResult Delete(Project project)
        {
            var result = _projectService.Delete(project);
            if (result.Success)
            {
                return Ok(result);
            }
            
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Project project)
        {
            var result = _projectService.Update(project);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


    }
}
