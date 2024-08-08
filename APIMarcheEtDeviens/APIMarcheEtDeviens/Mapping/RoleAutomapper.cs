using AutoMapper;
using APIMarcheEtDeviens.Models;

namespace APIMarcheEtDeviens.Mapping
{
	public class RoleAutomapper : Profile
	{
		public RoleAutomapper() 
		{
			CreateMap<RoleDto, Role>();
			CreateMap<Role, RoleDto>();

		}
	}
}
