using AutoMapper;
using Post.Common.Result;
using Post.Core.Dto.Membership;
using Post.Core.Dto.Subscription;
using Post.Core.Dto.Token;
using Post.Core.Token;
using Post.Database.EntityModels;

namespace Post.Core.Profiles;

public class AppProfile : Profile
{
    public AppProfile()
    {
        CreateMap<MembershipModel, MembershipDto>();
        CreateMap<MembershipRequestDto, ResultContainer<MembershipResponseDto>>()
            .ForMember("Data", opt
                => opt.MapFrom(u => u));
        
        CreateMap<MembershipRequestDto, MembershipResponseDto>();
        CreateMap<TokenModel, TokenDto>();
    }
}