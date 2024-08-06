using APIMarcheEtDeviens.Data;
using APIMarcheEtDeviens.Models;
using Microsoft.EntityFrameworkCore;

namespace APIMarcheEtDeviens.Repository
{
	public class RoleService : IController<int, Role>
	{
		private readonly DataContext _dataContext;
		public RoleService(DataContext dataContext)
		{

		_dataContext = dataContext;
		}

		public async Task<List<Role>> Add(Role role)
		{
			_dataContext.Role.Add(role);
			await _dataContext.SaveChangesAsync();

			return await _dataContext.Role.ToListAsync();
		}

		public async Task<List<Role>> GetAll()
		{
			return await _dataContext.Role.ToListAsync();
		}

		public async Task<Role> GetById(int id)
		{
			var role = _dataContext.Role.Find(id);
			if (role is null)
				return null;
			return role;
		}

		public async Task<List<Role>> Update(int id, Role request)
		{
			var dbRole = _dataContext.Role.Find(id);

			if (dbRole is null)
				return null;

			dbRole.Libelle = request.Libelle;

			await _dataContext.SaveChangesAsync();

			return await _dataContext.Role.ToListAsync();
		}

		public async Task<List<Role>> DeleteById(int id)
		{
			var dbRole = _dataContext.Role.Find(id);
			if (dbRole is null)
				return null;

			_dataContext.Role.Remove(dbRole);
			await _dataContext.SaveChangesAsync();

			return await _dataContext.Role.ToListAsync();
		}
	}
}
