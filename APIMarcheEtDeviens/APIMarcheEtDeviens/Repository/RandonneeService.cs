using APIMarcheEtDeviens.Data;
using APIMarcheEtDeviens.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIMarcheEtDeviens.Repository
{
	public class RandonneeService : IController<Guid, RandonneeDto>
	{
		private readonly DataContext _DbContext;
		private readonly IMapper _mapper;
		public RandonneeService(DataContext dataContext, IMapper mapper)
		{
			_DbContext = dataContext;
			_mapper = mapper;
		}


		//ajouter un randonneur
		public async Task<List<RandonneeDto>> Add(RandonneeDto randonnee)
		{
			var rando = _mapper.Map<Randonnee>(randonnee);
			rando.RandonneeId = Guid.NewGuid();

			_DbContext.Randonnee.Add(rando);
			await _DbContext.SaveChangesAsync();

			return await _DbContext.Randonnee.Select(randonnee => _mapper.Map<RandonneeDto>(randonnee)).ToListAsync();
		}
		public async Task<List<RandonneeDto>> GetAll()
		{
			return await _DbContext.Randonnee.Select(rando => _mapper.Map<RandonneeDto>(rando)).ToListAsync();
		}

		public async Task<RandonneeDto?> GetById(Guid id)
		{
			var randonnee = _DbContext.Randonnee.Find(id);
			if (randonnee == null) 
			{
				return null;
			}

			var dtoResult = _mapper.Map<RandonneeDto>(randonnee);

			return dtoResult;
		}

		public async Task<List<RandonneeDto?>> Update(Guid id, RandonneeDto request)
		{
			var dbRandonnee = _DbContext.Randonnee.Find(id);
			if (dbRandonnee == null)
			{
				return null;
			}

			dbRandonnee.NombreMaxPersonnes = request.NombreMaxPersonnes;
			dbRandonnee.Duree = request.Duree;
			dbRandonnee.NombreMaxPersonnes = request.NombreMaxPersonnes;
			dbRandonnee.Date = request.Date;
			dbRandonnee.Name = request.Name;
			dbRandonnee.Pays = request.Pays;
			dbRandonnee.Region = request.Region;
			dbRandonnee.Ville = request.Ville;
			dbRandonnee.PrixTotal = request.PrixTotal;
			dbRandonnee.Description = request.Description;

			await _DbContext.SaveChangesAsync();

			return await _DbContext.Randonnee.Select(rando => _mapper.Map<RandonneeDto>(rando)).ToListAsync();
		}

		//supprimer une randonnee
		public async Task<List<RandonneeDto?>> DeleteById(Guid id)
		{
			var randonnee = _DbContext.Randonnee.Find(id);
			if (randonnee == null)
			{
				return null;
			}
			_DbContext.Randonnee.Remove(randonnee);
			await _DbContext.SaveChangesAsync();

			return await _DbContext.Randonnee.Select(rando => _mapper.Map<RandonneeDto>(rando)).ToListAsync();
		}
	}
}
