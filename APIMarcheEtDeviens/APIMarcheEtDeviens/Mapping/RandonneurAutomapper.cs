using AutoMapper;
using APIMarcheEtDeviens.Models;
using APIMarcheEtDeviens.Services;

namespace APIMarcheEtDeviens.Mapping
{
	public class RandonneurAutomapper : Profile
	{
		public RandonneurAutomapper() 
		{
			CreateMap<Randonneur, RandonneurDTO>()
				.ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.Role.RoleId));

			CreateMap<RandonneurDTO, Randonneur>();
		}
	}
}
