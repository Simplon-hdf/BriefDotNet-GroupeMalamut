using APIMarcheEtDeviens.Models;
using APIMarcheEtDeviens.Repository;
using Microsoft.AspNetCore.Mvc;

namespace APIMarcheEtDeviens.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticiperController : ControllerBase
    {
        private readonly IController<int, Participer> participerService;
        public ParticiperController(IController<int, Participer> service)
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
        public async Task<ActionResult<Participer>> GetParticiperById(int id)
        {
            var result = await participerService.GetById(id);
            if (result is null)
                return NotFound("Not found");

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Participer>>> AddParticiper(Participer participer)
        {
            var result = await participerService.Add(participer);
            if (result is null)
                return NotFound("Not found...");
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Role>>> DeleteRole(int id)
        {
            var result = await participerService.DeleteById(id);
            if (result is null)
                return NotFound("Not found");

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<List<Role>>> Update(int id, Participer participer)
        {
            var result = await participerService.Update(id, participer);
            if (result is null)
                return NotFound("Not found");

            return Ok(result);
        }
    }
}