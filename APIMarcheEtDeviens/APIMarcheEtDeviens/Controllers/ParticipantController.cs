using APIMarcheEtDeviens.Data;
using APIMarcheEtDeviens.Models;
using APIMarcheEtDeviens.Repository;
using APIMarcheEtDeviens.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIMarcheEtDeviens.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantController : ControllerBase
    {
        private readonly IController<Guid, ParticipantDTO> participerService;
		private readonly DataContext _DbContext;
		private readonly IMapper _mapper;

		public ParticipantController(IController<Guid, ParticipantDTO> service, DataContext context, IMapper mapper)
        {
            participerService = service;
            _DbContext = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ParticipantDTO>>> GetAllParticiper()
        {
            var result = await participerService.GetAll();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ParticipantDTO>> GetParticiperById(Guid id)
        {
            var result = await participerService.GetById(id);
            if (result is null)
                return NotFound("Not found");

            return Ok(result);
        }

        [HttpGet("randonnee/{id}")]
		public async Task<ActionResult<List<RandonneurDTO>>> GetAllByRandonneeId(Guid id)
		{
			DbSet<Randonneur> randonneurs = _DbContext.Randonneur;
			DbSet<Participant> participers = _DbContext.Participer;

            var query = participers.GroupJoin(randonneurs,
                participer => participer.Randonneur.RandonneurId,
                randonneur => randonneur.RandonneurId,
                (participer, randonneur) => new
                {
                    randonneurParticipant = _mapper.Map<RandonneurDTO>(participer.Randonneur),
                    randonneeId = participer.Randonnee.RandonneeId
                });

			var allParticipants = new List<RandonneurDTO>();

			foreach (var participant in query)
			{
                if (participant.randonneeId == id)
                {
                    allParticipants.Add(participant.randonneurParticipant);
                } 
			}

            if (allParticipants.Count == 0)
                return NotFound("Il n'y a pas de participants pour cette randonnée");


			return Ok(allParticipants);
		}

		[HttpGet("randonneur/{id}")]
		public async Task<ActionResult<List<RandonneeDto>>> GetAllByRandonneurId(Guid id)
		{
			DbSet<Randonnee> randonnee = _DbContext.Randonnee;
			DbSet<Participant> participers = _DbContext.Participer;

			var query = participers.GroupJoin(randonnee,
				participer => participer.Randonnee.RandonneeId,
				randonnee => randonnee.RandonneeId,
				(participer, randonnee) => new
				{
					randonneeParticipee = _mapper.Map<RandonneeDto>(participer.Randonnee),
					randonneurId = participer.Randonneur.RandonneurId
				});

			var allParticipants = new List<RandonneeDto>();

			foreach (var participant in query)
			{
				if (participant.randonneurId == id)
				{
					allParticipants.Add(participant.randonneeParticipee);
				}
			}

			if (allParticipants.Count == 0)
				return NotFound("Ce randonneur n'as participé à aucune randonnée.");


			return Ok(allParticipants);
		}

		[HttpPost]
        public async Task<ActionResult<List<ParticipantDTO>>> AddParticiper(ParticipantDTO participer)
        {
            var result = await participerService.Add(participer);
            if (result is null)
                return NotFound("Not found...");
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<ParticipantDTO>>> DeleteRole(Guid id)
        {
            var result = await participerService.DeleteById(id);
            if (result is null)
                return NotFound("Not found");

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<List<ParticipantDTO>>> Update(Guid id, ParticipantDTO participer)
        {
            var result = await participerService.Update(id, participer);
            if (result is null)
                return NotFound("Not found");

            return Ok(result);
        }
    }
}