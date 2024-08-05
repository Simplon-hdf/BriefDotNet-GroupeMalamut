using APIMarcheEtDeviens.Data;
using APIMarcheEtDeviens.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIMarcheEtDeviens.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MediaController : ControllerBase
	{
		private readonly DataContext _context;
		public MediaController(DataContext context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<ActionResult<List<Media>>> GetAllMedias()
		{
			var medias = await _context.Media.ToListAsync();

			return Ok(medias);
		}

		
	}
}
