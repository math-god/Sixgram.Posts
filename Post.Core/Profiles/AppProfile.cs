using AutoMapper;
using Post.Common.Result;
using Post.Core.Dto.Subscription;
using Post.Core.Dto.Token;
using Post.Core.Token;
using Post.Database.EntityModels;

namespace Post.Core.Profiles;

public class AppProfile : Profile
{
    public AppProfile()
    {
        CreateMap<SubscriptionModel, SubscriptionDto>();
        CreateMap<List<SubscriptionModel>, ResultContainer<SubscriptionResponseDto>>()
            .ForMember("Data", opt
                => opt.MapFrom(u => u));
        
        CreateMap<TokenModel, TokenDto>();
    }
}