using AutoMapper;
using Post.Common.Result;
using Post.Core.Dto.Membership;
using Post.Core.Dto.Post;
using Post.Database.EntityModels;

namespace Post.Core.Profiles;

public class AppProfile : Profile
{
    public AppProfile()
    {
        CreateMap<MembershipRequestDto, ResultContainer<MembershipResponseDto>>()
            .ForMember("Data", opt
                => opt.MapFrom(m => m));

        CreateMap<PostModel, ResultContainer<CommentResponseDto>>()
            .ForMember("Data", opt
                => opt.MapFrom(c => c));

        CreateMap<PostModel, CommentResponseDto>()
            .ForMember("PostId", opt
                => opt.MapFrom(p => p.Id));

        CreateMap<PostModel, PostResponseDto>()
            .ForMember("PostId", opt
                => opt.MapFrom(p => p.Id));

        CreateMap<PostModel, ResultContainer<PostResponseDto>>()
            .ForMember("Data", opt
                => opt.MapFrom(p => p));

        CreateMap<PostModel, ResultContainer<PostUpdateResponseDto>>()
            .ForMember("Data", opt
                => opt.MapFrom(p => p));

        CreateMap<PostModel, PostUpdateResponseDto>();
        CreateMap<MembershipRequestDto, MembershipResponseDto>();
    }
}