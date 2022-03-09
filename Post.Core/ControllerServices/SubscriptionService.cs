using AutoMapper;
using Post.Common.Response;
using Post.Common.Result;
using Post.Core.Dto.Subscription;
using Post.Core.Http;
using Post.Core.Subscription;
using Post.Core.Token;
using Post.Database.EntityModels;
using Post.Database.Repository.Subscription;

namespace Post.Core.ControllerServices;

public class SubscriptionService : ISubscriptionService
{
    private readonly ISubscriptionRepository _subscriptionRepository;
    private readonly IMapper _mapper;
    private readonly ITokenService _tokenService;
    private readonly IUserHttpService _userHttpService;

    public SubscriptionService
    (
        IMapper mapper,
        ISubscriptionRepository subscriptionRepository,
        ITokenService tokenService,
        IUserHttpService userHttpService
    )
    {
        _subscriptionRepository = subscriptionRepository;
        _mapper = mapper;
        _tokenService = tokenService;
        _userHttpService = userHttpService;
    }

    public async Task<ResultContainer> Subscribe(SubscribeRequestDto subscribeRequestDto)
    {
        var result = new ResultContainer();
        var currentUserId = _tokenService.GetCurrentUserId();

        /*var subscriptionsAmount = await _subscriptionRepository.GetByFilter(p =>
            p.RespondentId == subscribeRequestDto.RespondentId && p.SubscriberId == currentUserId);*/

        if (subscribeRequestDto.RespondentId == currentUserId /*|| subscriptionsAmount.Any()*/)
        {
            result.ResponseStatusCode = ResponseStatusCode.BadRequest;
            return result;
        }

        var userExists = await _userHttpService.DoesUserExist(subscribeRequestDto.RespondentId);

        switch (userExists)
        {
            case null:
                result.ResponseStatusCode = ResponseStatusCode.ServiceUnavailable;
                return result;
            case false:
                result.ResponseStatusCode = ResponseStatusCode.NotFound;
                return result;
        }

        var subscriptionModel = new SubscriptionModel()
        {
            RespondentId = subscribeRequestDto.RespondentId,
            SubscriberId = currentUserId
        };

        await _subscriptionRepository.Create(subscriptionModel);

        result.ResponseStatusCode = ResponseStatusCode.NoContent;

        return result;
    }

    public async Task<ResultContainer> Unsubscribe(Guid subscriptionId)
    {
        var result = new ResultContainer();

        var subscription = await _subscriptionRepository.GetById(subscriptionId);

        if (subscription == null)
        {
            result.ResponseStatusCode = ResponseStatusCode.NotFound;
            return result;
        }

        await _subscriptionRepository.Delete(subscription);

        result.ResponseStatusCode = ResponseStatusCode.NoContent;

        return result;
    }

    public async Task<ResultContainer<SubscriptionModelResponseDto>> GetById(Guid subscriptionId)
    {
        var result = new ResultContainer<SubscriptionModelResponseDto>();

        var subscription = await _subscriptionRepository.GetById(subscriptionId);

        if (subscription == null)
        {
            result.ResponseStatusCode = ResponseStatusCode.NotFound;
            return result;
        }

        result = _mapper.Map<ResultContainer<SubscriptionModelResponseDto>>(subscription);

        result.ResponseStatusCode = ResponseStatusCode.Ok;

        return result;
    }
}