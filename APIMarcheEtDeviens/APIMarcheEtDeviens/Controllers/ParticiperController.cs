using APIMarcheEtDeviens.Models;
using APIMarcheEtDeviens.Repository;
using Microsoft.AspNetCore.Mvc;

namespace APIMarcheEtDeviens.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticiperController : ControllerBase
    {
        private readonly IController<int, ParticiperDto> participerService;
        public ParticiperController(IController<int, ParticiperDto> service)
        {
            participerService = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<ParticiperDto>>> GetAllParticiper()
        {
            var result = await participerService.GetAll();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ParticiperDto>> GetParticiperById(int id)
        {
            var result = await participerService.GetById(id);
            if (result is null)
                return NotFound("Not found");

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<ParticiperDto>>> AddParticiper(ParticiperDto participer)
        {
            var result = await participerService.Add(participer);
            if (result is null)
                return NotFound("Not found...");
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<ParticiperDto>>> DeleteRole(int id)
        {
            var result = await participerService.DeleteById(id);
            if (result is null)
                return NotFound("Not found");

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<List<ParticiperDto>>> Update(int id, ParticiperDto participer)
        {
            var result = await participerService.Update(id, participer);
            if (result is null)
                return NotFound("Not found");

            return Ok(result);
        }
    }
}