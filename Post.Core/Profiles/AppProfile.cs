using AutoMapper;
using Post.Common.Result;
using Post.Core.Dto.Comment;
using Post.Core.Dto.Like;
using Post.Core.Dto.Post;
using Post.Core.Dto.Subscription;
using Post.Database.EntityModels;

namespace Post.Core.Profiles;

public class AppProfile : Profile
{
    public AppProfile()
    {
        CreateMap<PostModel, PostCreateResponseDto>()
            .ForMember("PostId", opt
                => opt.MapFrom(p => p.Id));

        CreateMap<PostModel, ResultContainer<PostCreateResponseDto>>()
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
            .ForMember("Posts", opt
                => opt.MapFrom(p => p));

        CreateMap<PostModel, PostModelResponseDto>()
            .ForMember("PostId", opt
                => opt.MapFrom(p => p.Id));

        CreateMap<SubscriptionModel, ResultContainer<SubscriptionModelResponseDto>>()
            .ForMember("Data", opt
                => opt.MapFrom(p => p));
        
        CreateMap<SubscriptionModel, ResultContainer<SubscribeResponseDto>>()
            .ForMember("Data", opt
                => opt.MapFrom(p => p));
        
        CreateMap<SubscriptionModel, SubscribeResponseDto>()
            .ForMember("SubscriptionId", opt
                => opt.MapFrom(p => p.Id));
        
        CreateMap<LikeModel, ResultContainer<LikeResponseDto>>()
            .ForMember("Data", opt
                => opt.MapFrom(p => p));
        
        CreateMap<LikeModel, LikeResponseDto>()
            .ForMember("LikeId", opt
                => opt.MapFrom(p => p.Id));
        
        CreateMap<List<LikeModel>, ResultContainer<LikeModelsResponseDto>>()
            .ForMember("Data", opt
                => opt.MapFrom(p => p));
        
        CreateMap<List<LikeModel>, LikeModelsResponseDto>()
            .ForMember("Likes", opt
                => opt.MapFrom(p => p));
        
        CreateMap<LikeModel, LikeModelResponseDto>()
            .ForMember("LikeId", opt
                => opt.MapFrom(p => p.Id));
        
        CreateMap<CommentaryModel, ResultContainer<CommentCreateResponseDto>>()
            .ForMember("Data", opt
                => opt.MapFrom(p => p));
        
        CreateMap<CommentaryModel, CommentCreateResponseDto>()
            .ForMember("CommentId", opt
                => opt.MapFrom(p => p.Id));

        CreateMap<CommentaryModel, ResultContainer<CommentModelResponseDto>>()
            .ForMember("Data", opt
                => opt.MapFrom(p => p.Id));
        

        CreateMap<CommentaryModel, CommentModelResponseDto>();
        CreateMap<SubscriptionModel, SubscriptionModelResponseDto>();
        CreateMap<PostModel, PostUpdateResponseDto>();
    }
}