using APIMarcheEtDeviens.Data;
using APIMarcheEtDeviens.Models;
using Microsoft.EntityFrameworkCore;

namespace APIMarcheEtDeviens.Repository
{
	public class RandonneeService : IController<Guid, Randonnee>
	{
		private readonly DataContext _dataContext;
		public RandonneeService(DataContext dataContext)
		{

			_dataContext = dataContext;
		}


		//ajouter un randonneur
		public async Task<List<Randonnee>> Add(Randonnee randonnee)
		{
			_dataContext.Randonnee.Add(randonnee);
			await _dataContext.SaveChangesAsync();

			return await _dataContext.Randonnee.ToListAsync();
		}
		public async Task<List<Randonnee>> GetAll()
		{
			return await _dataContext.Randonnee.ToListAsync();
		}

		public async Task<Randonnee?> GetById(Guid id)
		{
			var randonnee = _dataContext.Randonnee.Find(id);
			if (randonnee == null) 
			{
				return null;
			}
			return randonnee;
		}

		public async Task<List<Randonnee?>> Update(Guid id, Randonnee request)
		{
			var dbRandonnee = _dataContext.Randonnee.Find(id);
			if (dbRandonnee == null)
			{
				return null;
			}
			dbRandonnee.Libelle = request.Libelle;

			await _dataContext.SaveChangesAsync();

			return await _dataContext.Randonnee.ToListAsync();
		}

		//supprimer une randonnee
		public async Task<List<Randonnee?>> DeleteById(Guid id)
		{
			var randonnee = _dataContext.Randonnee.Find(id);
			if (randonnee == null)
			{
				return null;
			}
			_dataContext.Randonnee.Remove(randonnee);
			await _dataContext.SaveChangesAsync();

			return await _dataContext.Randonnee.ToListAsync();
		}
	}
}
