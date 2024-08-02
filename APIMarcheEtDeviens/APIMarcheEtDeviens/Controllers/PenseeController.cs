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
			var pensees = await _context.Pensees.ToListAsync();

			return Ok(pensees);
		}

		[HttpPost]
		public async Task<ActionResult<List<Pensee>>> AddPensee()
		{
			List<Pensee> pensees = new List<Pensee> {
				new Pensee
				{
					Id = "1",
					NomDeLaPensee = "Pensee 1",
					ContenuPensee = "Lorem",
					Date = new DateTime(),
					Media = null
				},
				new Pensee
				{
					Id = "2",
					NomDeLaPensee = "Pensee 2",
					ContenuPensee = "Ipsum",
					Date = new DateTime(),
					Media = null
				},
				new Pensee
				{
					Id = "3",
					NomDeLaPensee = "Pensee 3",
					ContenuPensee = "Dolor",
					Date = new DateTime(),
					Media = null
				}
				};


			foreach (Pensee pensee in pensees)
			{
				_context.Pensees.Add(pensee);
				_context.SaveChanges();
			}

			return Ok(await _context.Pensees.ToListAsync());
		}

	}
}
