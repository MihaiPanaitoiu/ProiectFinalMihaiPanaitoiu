using Microsoft.AspNetCore.Mvc;
using Data.Exceptions;
using ProiectFinalMihaiPanaitoiu.Controllers.DTOS;
using ProiectFinalMihaiPanaitoiu.Utils;
using Data.Models;
using Data.Models.Interfaces;

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
        /// Seed database
        /// </summary>
        [HttpPost("seed")]
        public void Seed() => dals.Seed();

        /// <summary>
        /// Returns all the students
        /// </summary>
        [HttpGet]
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
        public ActionResult<StudentToGetDto> GetStudentById(int id) {
            try {
                return Ok(dals.GetStudentById(id).ToDto());
            }
            catch (InvalidIdException e) {
                return NotFound(e.Message);
            } 
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
            try
            {
                return Created("success",dals.CreateStudent(studentToCreate.ToEntity()).ToDto());
            } catch (InvalidIdException e)
            {
                return BadRequest(e.Message);
            }
        }
           

        /// <summary>
        /// Updates a student
        /// </summary>
        /// <param name="studentToUpdate">student to update data</param>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpPatch]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(void))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public ActionResult<StudentToGetDto> UpdateStudent([FromBody] StudentToUpdateDto studentToUpdate)
        {
            try
            {
                return Ok(dals.UpdateStudent(studentToUpdate.ToEntity()).ToDto());
            } catch (InvalidIdException e)
            {
                return NotFound(e.Message);
            }
        }

        /// <summary>
        /// Updates or creates a student address
        /// </summary>
        /// <param name="id">Student Id</param>
        /// <param name="addressToUpdate">Address</param>
        [HttpPut("${id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(void))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public ActionResult<Address> UpdateStudentAddress([FromRoute] int id, [FromBody] AddressToUpdateDto addressToUpdate)
        {
            try
            {
                return Ok(dals.UpdateStudentAddress(id, addressToUpdate.ToEntity()));
            } catch (InvalidIdException e)
            {
                return NotFound(e.Message);
            }
        }


        /// <summary>
        /// Deletes a student by Id
        /// </summary>
        /// <param name="id">Student Id</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(void))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public IActionResult DeleteStudent([FromRoute] int id) {
            try {
               dals.DeleteStudent(id);
            } catch(InvalidIdException e) {
                return NotFound(e.Message);
            }
            return Ok();
        }
}
}
