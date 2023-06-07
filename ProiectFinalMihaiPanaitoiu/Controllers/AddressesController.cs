using Data.Exceptions;
using Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectFinalMihaiPanaitoiu.DTOS;
using ProiectFinalMihaiPanaitoiu.Utils;
using System.ComponentModel.DataAnnotations;

namespace ProiectFinalMihaiPanaitoiu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly IDataAccessLayerService dals;

        public AddressesController(IDataAccessLayerService dals)
        {
            this.dals = dals;
        }

        /// <summary>
        /// Updates or creates a student address
        /// </summary>
        /// <param name="id">Student Id</param>
        /// <param name="addressToUpdate">Address</param>
        [HttpPut("${id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(void))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public ActionResult<Address> UpdateStudentAddress
            ([FromRoute] [Range(1, int.MaxValue)]int id, [FromBody] AddressToUpdateDto addressToUpdate) =>
            Ok(dals.UpdateStudentAddress(id, addressToUpdate.ToEntity()));
    }
}
