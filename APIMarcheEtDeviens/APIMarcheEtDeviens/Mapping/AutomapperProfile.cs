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
				.ForMember(dest => dest.IdRandonnee, opt => opt.MapFrom(src => src.Randonnee.RandonneeId));
            CreateMap<MediaDto, Media>();
			CreateMap<Pensee, PenseeDto>()
							.ForMember(dest => dest.MediaId, opt => opt.MapFrom(src => src.Media.MediaId));
			CreateMap<PenseeDto, Pensee>();
			CreateMap<Randonnee, RandonneeDto>();
			CreateMap<RandonneeDto, Randonnee>();
			CreateMap<Randonneur, RandonneurDTO>()
				.ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.Role.RoleId));
			CreateMap<RandonneurDTO, Randonneur>();
			CreateMap<RoleDto, Role>();
			CreateMap<Role, RoleDto>();
			CreateMap<Participer, ParticiperDto>();
			CreateMap<ParticiperDto, Participer>();
		}
    }
}
