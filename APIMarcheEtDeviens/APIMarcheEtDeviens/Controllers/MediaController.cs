using APIMarcheEtDeviens.Data;
using APIMarcheEtDeviens.Models;
using Microsoft.AspNetCore.Mvc;
using MySql.EntityFrameworkCore;

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
		public async Task<ActionResult<List<Pensee>>> GetAllPensees()
		{
			var medias = await _context.Medias.ToListAsync();

			return Ok(medias);
		}

		[HttpPost]
		public async Task<ActionResult<List<Media>>> AddPensee()
		{
			List<Media> medias = new List<Media> {
				new Media
				{
					Id = "1",
					CheminDuMedia = "",
					NomMedia = "Media1",
					TypeMedia = "Photo",
				},
				new Media
				{
					Id = "2",
					CheminDuMedia = "",
					NomMedia = "Media2",
					TypeMedia = "Video",
				},
				new Media
				{
					Id = "3",
					CheminDuMedia = "",
					NomMedia = "Media3",
					TypeMedia = "Photo",
				}
				};


			foreach (Media media in medias)
			{
				_context.Medias.Add(media);
				_context.SaveChanges();
			}

			return Ok(await _context.Medias.ToListAsync());
		}
	}
}
