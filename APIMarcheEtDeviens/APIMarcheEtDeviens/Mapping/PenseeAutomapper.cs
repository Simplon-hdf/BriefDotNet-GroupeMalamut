using AutoMapper;
using APIMarcheEtDeviens.Models;

namespace APIMarcheEtDeviens.Mapping
{
	public class PenseeAutomapper : Profile
	{
		public PenseeAutomapper() 
		{
			CreateMap<Pensee,  PenseeDto>()
							.ForMember(dest => dest.NomMedia, opt => opt.MapFrom(src => src.Media.NomMedia));
			CreateMap<PenseeDto, Pensee>();
		}
	}
}
