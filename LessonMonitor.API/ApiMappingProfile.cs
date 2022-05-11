using AutoMapper;

namespace LessonMonitor.API
{
    public class ApiMappingProfile : Profile
    {
        public ApiMappingProfile()
        {
            CreateMap<Core.Member, Contracts.Member>().ReverseMap();
            CreateMap<Contracts.NewMember, Core.Member>();
        }
    }
}
