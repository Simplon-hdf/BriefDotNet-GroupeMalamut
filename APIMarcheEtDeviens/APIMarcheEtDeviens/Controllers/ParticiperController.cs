using APIMarcheEtDeviens.Models;
using APIMarcheEtDeviens.Repository;
using Microsoft.AspNetCore.Mvc;

namespace APIMarcheEtDeviens.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticiperController : ControllerBase
    {
        private readonly IController<Guid, Participer> participerService;
        public ParticiperController(IController<Guid, Participer> service)
        {
            participerService = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Participer>>> GetAllParticiper()
        {
            var result = await participerService.GetAll();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Participer>> GetParticiperById(Guid id)
        {
            var result = await participerService.GetById(id);
            if (result is null)
                return NotFound("Not found");

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Participer>>> AddParticiper(Media participer)
        {
            var result = await participerService.Add(participer);
            if (result is null)
                return NotFound("Not found...");
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Role>>> DeleteRole(Guid id)
        {
            var result = await participerService.DeleteById(id);
            if (result is null)
                return NotFound("Not found");

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<List<Role>>> Update(Guid id, Participer participer)
        {
            var result = await participerService.Update(id, participer);
            if (result is null)
                return NotFound("Not found");

            return Ok(result);
        }
    }
}