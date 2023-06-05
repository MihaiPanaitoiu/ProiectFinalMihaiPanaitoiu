using Data.Exceptions;
using Data.Models;
using Data.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectFinalMihaiPanaitoiu.Controllers.DTOS;
using ProiectFinalMihaiPanaitoiu.Utils;

namespace ProiectFinalMihaiPanaitoiu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarksController : ControllerBase
    {
        private readonly IDataAccessLayerService dals;

        public MarksController(IDataAccessLayerService dals)
        {
            this.dals = dals;
        }


        /// <summary>
        /// Add a mark to a student and a course
        /// </summary>
        /// <param name="markToCreate"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(void))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public ActionResult<MarkToGetDto> CreateMark([FromBody] MarkToCreateDto markToCreate)
        {
            try
            {
                return Created("success", dals.CreateMark(markToCreate.ToEntity()).ToDto());
            }
            catch (InvalidIdException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("/{studentId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(void))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public IEnumerable<MarkToGetDto?> GetMarksByStudentId([FromRoute] int studentId) => dals.GetMarksByStudentId(studentId).Select(x => x.ToDto());


        [HttpGet("/{studentId}/{courseId}")]
        public IEnumerable<MarkToGetDto?> GetByStudentAndCourse([FromRoute] int studentId, [FromRoute] int courseId)
            => dals.GetByStudentAndCourse(studentId, courseId).ToDto();

        [HttpGet("/{studentId}/{courseId}/avg")]
        public double GetAvgByStudentAndCourse([FromRoute] int studentId, [FromRoute] int courseId)
            => dals.GetAvgByStudentAndCourse(studentId, courseId);
    }
}
