using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Data;
using Data.Exceptions;
using ProiectFinalMihaiPanaitoiu.Controllers.DTOS;
using ProiectFinalMihaiPanaitoiu.Utils;
using Microsoft.SqlServer.Server;

namespace ProiectFinalMihaiPanaitoiu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        /// <summary>
        /// Seed database
        /// </summary>
        [HttpPost("seed")]
        public void Seed() => DataAccessLayerSingleton.Instance.Seed();

        /// <summary>
        /// Returns all the students
        /// </summary>
        [HttpGet]
        public IEnumerable<StudentToGetDto> GetStudents() =>
            DataAccessLayerSingleton.Instance.GetStudents().Select(x => x.ToDto()).ToList();

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
                return Ok(DataAccessLayerSingleton.Instance.GetStudentById(id).ToDto());
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
        public StudentToGetDto CreateStudent([FromBody] StudentToCreateDto studentToCreate) => 
            DataAccessLayerSingleton.Instance.CreateStudent(studentToCreate.ToEntity()).ToDto();

        /// <summary>
        /// Updates a student
        /// </summary>
        /// <param name="studentToUpdate">student to update data</param>
        /// <param name=""></param>
        /// <returns></returns>

        [HttpPatch]
        public StudentToGetDto UpdateStudent([FromBody] StudentToUpdateDto studentToUpdate) =>
            DataAccessLayerSingleton.Instance.UpdateStudent(studentToUpdate.ToEntity()).ToDto();

        /// <summary>
        /// Updates or creates a student address
        /// </summary>
        /// <param name="id">Student Id</param>
        /// <param name="addressToUpdate">Address</param>
        [HttpPut("${id}")]
        public void UpdateStudentAddress([FromRoute] int id, [FromBody] AddressToUpdateDto addressToUpdate) =>
            DataAccessLayerSingleton.Instance.UpdateStudentAddress(id, addressToUpdate.ToEntity());


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
                DataAccessLayerSingleton.Instance.DeleteStudent(id);
            } catch(InvalidIdException e) {
                return NotFound(e.Message);
            }
            return Ok();
        }

}
}
