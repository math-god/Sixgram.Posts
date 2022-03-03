using AutoMapper;
using Post.Common.Result;
using Post.Core.Dto.Post;
using Post.Core.Dto.Subscription;
using Post.Database.EntityModels;

namespace Post.Core.Profiles;

public class AppProfile : Profile
{
    public AppProfile()
    {
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

        CreateMap<PostModel, ResultContainer<PostModelResponseDto>>()
            .ForMember("Data", opt
                => opt.MapFrom(p => p)); 
        
        CreateMap<IEnumerable<PostModel>, ResultContainer<PostModelsResponseDto>>()
            .ForMember("Data", opt
                => opt.MapFrom(p => p)); 
        
        CreateMap<IEnumerable<PostModel>, PostModelsResponseDto>()
            .ForMember("_posts", opt
                => opt.MapFrom(p => p));

        CreateMap<PostModel, PostModelResponseDto>()
            .ForMember("PostId", opt
                => opt.MapFrom(p => p.Id));

        CreateMap<SubscriptionModel, ResultContainer<SubscriptionModelResponseDto>>()
            .ForMember("Data", opt
                => opt.MapFrom(p => p));

        CreateMap<CommentaryModel, ResultContainer<CommentModelResponseDto>>()
            .ForMember("Data", opt
                => opt.MapFrom(p => p));

        CreateMap<CommentaryModel, CommentModelResponseDto>();
        CreateMap<SubscriptionModel, SubscriptionModelResponseDto>();
        CreateMap<PostModel, PostUpdateResponseDto>();
    }
}