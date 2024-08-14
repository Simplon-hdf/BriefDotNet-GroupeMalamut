using AutoMapper;
using APIMarcheEtDeviens.Models;
using APIMarcheEtDeviens.Services;

namespace APIMarcheEtDeviens.Mapping
{
	public class AutomapperProfile : Profile
	{
		public AutomapperProfile()
		{
			CreateMap<Media, MediaDto>()
				.ForMember(dest => dest.IdRandonnee, opt => opt.MapFrom(src => src.Randonnee.RandonneeId))
				.ReverseMap();

			CreateMap<Pensee, PenseeDto>()
				.ForMember(dest => dest.MediaId, opt => opt.MapFrom(src => src.Media.MediaId))
				.ReverseMap();

			CreateMap<Randonnee, RandonneeDto>()
				.ReverseMap();

			CreateMap<Randonneur, RandonneurDTO>()
				.ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.Role.RoleId))
				.ReverseMap();

			CreateMap<RoleDto, Role>()
				.ReverseMap();

			CreateMap<Participant, ParticipantDTO>()
				.ReverseMap();

		}
	}
}
