using AutoMapper;
using Post.Common.Error;
using Post.Common.Result;
using Post.Core.Dto.Subscription;
using Post.Core.Subscription;
using Post.Database.Repository.Subscription;

namespace Post.Core.Services
{
    public class SubscribeService : ISubscriptionService
    {
        /*private readonly ITokenService _tokenService;*/
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IMapper _mapper;
        
        public SubscribeService
        (
            /*ITokenService tokenService,*/
            IMapper mapper,
            ISubscriptionRepository subscriptionRepository
            
        )
        {
            /*_tokenService = tokenService;*/
            _mapper = mapper;
            _subscriptionRepository = subscriptionRepository;
        }
        

        public async Task<ResultContainer<SubscriptionResponseDto>> Subscribe(Guid respondentId, Guid subscriberId)
        {
            var result = new ResultContainer<SubscriptionResponseDto>();
            
            var respondent = _subscriptionRepository.GetById(respondentId).Result;
            var subscriber = _subscriptionRepository.GetById(subscriberId).Result;

            if (respondent == null || subscriber == null)
            {
                result.ErrorType = ErrorType.BadRequest;
                return result;
            }


            throw new NotImplementedException();

        }

        public Task<ResultContainer<SubscriptionResponseDto>> Unsubscribe(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}