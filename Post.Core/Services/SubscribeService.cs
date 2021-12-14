using AutoMapper;
using Post.Database.Repository.Subscription;

namespace Post.Core.Services
{
    public class SubscribeService
    {
        /*private readonly ITokenService _tokenService;*/
        private readonly IMapper _mapper;
        private readonly ISubscriptionRepository _subscriptionRepository;

        public SubscribeService
        (
            /*ITokenService tokenService,*/
            IMapper mapper,
            ISubscriptionRepository userRepository
        )
        {
            /*_tokenService = tokenService;*/
            _mapper = mapper;
            _subscriptionRepository = userRepository;
        }

        /*public async Task<ResultContainer<SubscriptionResponseDto>> Subscribe(Guid userId)
        {
            var result = new ResultContainer<SubscriptionResponseDto>();
        
            var user = _subscriptionRepository.GetById(userId);
            
            
        }
        
         public async Task<ResultContainer<SubscriptionResponseDto>> Unsubscribe(Guid userId)
        {
             throw new NotImplementedException();
        }*/
    }
}