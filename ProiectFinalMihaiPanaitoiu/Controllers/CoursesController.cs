using Data.Exceptions;
using Data.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectFinalMihaiPanaitoiu.Controllers.DTOS;
using ProiectFinalMihaiPanaitoiu.Utils;

namespace ProiectFinalMihaiPanaitoiu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly IDataAccessLayerService dals;

        public CoursesController(IDataAccessLayerService dals)
        {
            this.dals = dals;
        }

        /// <summary>
        /// Create a new course
        /// </summary>
        /// <param name="courseToCreate">Name of the course</param>
        /// <returns>created course</returns>

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(void))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public ActionResult<CourseToGetDto> CreateCourse([FromBody] CourseToCreateDto courseToCreate)
        {
            try
            {
                return Created("success", dals.CreateCourse(courseToCreate.ToEntity()).ToDto());
            }
            catch (InvalidIdException e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Returns all Courses
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(void))]
        public IEnumerable<CourseToGetDto> GetCourses() => dals.GetCourses().Select(x => x.ToDto()).ToList();
    }
}
