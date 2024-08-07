using AutoMapper;
using APIMarcheEtDeviens.Models;

namespace APIMarcheEtDeviens.Mapping
{
    public class MediaAutomapper : Profile
    {
        public MediaAutomapper()
        {
            CreateMap<Media, MediaDto>();
        }
    }
}
