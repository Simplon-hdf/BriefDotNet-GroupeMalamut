using APIMarcheEtDeviens.Data;
using APIMarcheEtDeviens.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIMarcheEtDeviens.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RandonneurController : ControllerBase
	{
		private readonly DataContext _context;
		public RandonneurController(DataContext context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<ActionResult<List<Randonneur>>> GetAllRandonneurs()
		{
			var randonneurs = await _context.Randonneur.ToListAsync();

			return Ok(randonneurs);
		}

	}
}

