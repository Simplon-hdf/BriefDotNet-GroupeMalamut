using APIMarcheEtDeviens.Data;
using APIMarcheEtDeviens.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIMarcheEtDeviens.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PenseeController : ControllerBase
	{
		private readonly DataContext _context;
		public PenseeController(DataContext context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<ActionResult<List<Pensee>>> GetAllPensees()
		{
			var pensees = await _context.Pensee.ToListAsync();

			return Ok(pensees);
		}

		

	}
}
