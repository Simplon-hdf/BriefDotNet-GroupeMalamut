using APIMarcheEtDeviens.Data;
using APIMarcheEtDeviens.Models;
using APIMarcheEtDeviens.Services;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace APIMarcheEtDeviens.Repository
{
    public class RoleService : IController<int, RoleDto>
	{
		private readonly DataContext _DbContext;
		private readonly IMapper _mapper;
		public RoleService(DataContext dataContext, IMapper mapper)
		{
			_mapper = mapper;
			_DbContext = dataContext;
		}

		public async Task<List<RoleDto>> Add(RoleDto role)
		{
			var roleInput = _mapper.Map<Role>(role);

			_DbContext.Role.Add(roleInput);
			await _DbContext.SaveChangesAsync();

			return await _DbContext.Role.Select(media => _mapper.Map<RoleDto>(media)).ToListAsync();
		}

		public async Task<List<RoleDto>> GetAll()
		{
			return await _DbContext.Role.Select(media => _mapper.Map<RoleDto>(media)).ToListAsync();
		}

		public async Task<RoleDto> GetById(int id)
		{
			var role = _DbContext.Role.Find(id);
			if (role is null)
				return null;
			return _mapper.Map<RoleDto>(role);
		}

		public async Task<List<RoleDto>> Update(int id, RoleDto request)
		{
			var dbRole = _DbContext.Role.Find(id);

			if (dbRole is null)
				return null;

			dbRole.Libelle = request.Libelle;

			await _DbContext.SaveChangesAsync();

			return await _DbContext.Role.Select(media => _mapper.Map<RoleDto>(media)).ToListAsync();
		}

		public async Task<List<RoleDto>> DeleteById(int id)
		{
			var dbRole = _DbContext.Role.Find(id);
			if (dbRole is null)
				return null;

			_DbContext.Role.Remove(dbRole);
			await _DbContext.SaveChangesAsync();

			return await _DbContext.Role.Select(media => _mapper.Map<RoleDto>(media)).ToListAsync();
		}
	}
}
