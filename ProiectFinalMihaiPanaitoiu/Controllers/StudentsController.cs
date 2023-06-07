using Microsoft.AspNetCore.Mvc;
using Data.Exceptions;
using ProiectFinalMihaiPanaitoiu.Utils;
using Data.Models;
using Data.Services;
using ProiectFinalMihaiPanaitoiu.DTOS;
using System.ComponentModel.DataAnnotations;

namespace ProiectFinalMihaiPanaitoiu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IDataAccessLayerService dals;

        public StudentsController(IDataAccessLayerService dals)
        {
            this.dals = dals;
        }

        /// <summary>
        /// Returns all the students
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentToGetDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public IEnumerable<StudentToGetDto> GetStudents() =>
           dals.GetStudents().Select(x => x.ToDto()).ToList();

        /// <summary>
        /// returns student by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type=typeof(StudentToGetDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound ,Type=typeof(string))]
        public ActionResult<StudentToGetDto> GetStudentById([Range(1, int.MaxValue)]int id) {
                return Ok(dals.GetStudentById(id).ToDto());
        }


        /// <summary>
        /// Creates a student
        /// </summary>
        /// <param name="studentToCreate">student to create data</param>
        /// <returns>created student data</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(void))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public ActionResult<StudentToGetDto> CreateStudent([FromBody] StudentToCreateDto studentToCreate)
        {
            return Created("success",dals.CreateStudent(studentToCreate.ToEntity()).ToDto());
        }

        /// <summary>
        /// Updates a student
        /// </summary>
        /// <param name="studentToUpdate">student to update data</param>
        /// <returns></returns>
        [HttpPatch]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(void))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public ActionResult<StudentToGetDto> UpdateStudent([FromBody] StudentToUpdateDto studentToUpdate)
        {
                return Ok(dals.UpdateStudent(studentToUpdate.ToEntity()).ToDto());
        }

        /// <summary>
        /// Deletes a student by Id
        /// </summary>
        /// <param name="id">Student Id</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(void))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public IActionResult DeleteStudent([FromRoute] int id) {
            dals.DeleteStudent(id);
            return Ok();
        }
      
        /// <summary>
        /// Get student general aritmetic mean in ASC or DESC order
        /// </summary>
        /// <param name="sortDir"></param>
        /// <returns></returns>
       [HttpGet("/aritmeticMean")]
       [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(void))]
       [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public IEnumerable<StudentToAritmeticMeanDto> GetAritmeticMean([FromQuery] SortDirectionEnum sortDir)
           => dals.GetAritmeticMean(sortDir).ToDto();
    }
}
