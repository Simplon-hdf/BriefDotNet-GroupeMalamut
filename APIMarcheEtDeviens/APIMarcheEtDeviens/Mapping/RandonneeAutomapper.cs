using AutoMapper;
using APIMarcheEtDeviens.Models;

namespace APIMarcheEtDeviens.Mapping
{
	public class RandonneeAutomapper : Profile
	{
		public RandonneeAutomapper()
		{
			CreateMap<Randonnee, RandonneeDto>();
			CreateMap<RandonneeDto, Randonnee>();
		}
	}
}
