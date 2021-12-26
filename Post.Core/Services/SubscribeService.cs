using AutoMapper;
using Post.Common.Result;
using Post.Core.Dto.Subscription;
using Post.Core.Subscription;

namespace Post.Core.Services
{
    public class SubscribeService : ISubscriptionService
    {
        /*private readonly ITokenService _tokenService;*/
        private readonly IMapper _mapper;


        public SubscribeService
        (
            /*ITokenService tokenService,*/
            IMapper mapper
        )
        {
            /*_tokenService = tokenService;*/
            _mapper = mapper;
        }

        public Task<ResultContainer<SubscriptionResponseDto>> Subscribe(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<ResultContainer<SubscriptionResponseDto>> Unsubscribe(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}