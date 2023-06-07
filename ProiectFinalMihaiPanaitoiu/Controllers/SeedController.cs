using Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProiectFinalMihaiPanaitoiu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeedController : ControllerBase
    {
        private readonly IDataAccessLayerService dals;

        public SeedController(IDataAccessLayerService dals)
        {
            this.dals = dals;
        }

        /// <summary>
        /// Seed database
        /// </summary>
        [HttpPost]
        public void Seed() => dals.Seed();
    }
}
