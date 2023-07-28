using BlogModels.Dto;
using BlogModels;
using AutoMapper;

namespace BlogAPI
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Subscription, SubscriptionDto>().ReverseMap();
        }
    }
}
