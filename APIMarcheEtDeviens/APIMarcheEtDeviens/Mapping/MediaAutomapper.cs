using AutoMapper;
using APIMarcheEtDeviens.Models;

namespace APIMarcheEtDeviens.Mapping
{
    public class MediaAutomapper : Profile
    {
        public MediaAutomapper()
        {
            CreateMap<Media, MediaDto>()
				.ForMember(dest => dest.NomRandonnee, opt => opt.MapFrom(src => src.Randonnee.Name));
            CreateMap<MediaDto, Media>();

		}
    }
}
