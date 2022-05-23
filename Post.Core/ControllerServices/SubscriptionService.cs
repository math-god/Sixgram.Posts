using AutoMapper;
using Post.Common.Response;
using Post.Common.Result;
using Post.Core.Dto.Subscription;
using Post.Core.Interfaces.Http;
using Post.Core.Interfaces.Subscription;
using Post.Core.Interfaces.User;
using Post.Database.EntityModels;
using Post.Database.Repository.Subscription;

namespace Post.Core.ControllerServices;

public class SubscriptionService : ISubscriptionService
{
    private readonly ISubscriptionRepository _subscriptionRepository;
    private readonly IMapper _mapper;
    private readonly IUserIdentityService _itUserIdentityService;
    private readonly IUserHttpService _userHttpService;

    public SubscriptionService
    (
        IMapper mapper,
        ISubscriptionRepository subscriptionRepository,
        IUserIdentityService itUserIdentityService,
        IUserHttpService userHttpService
    )
    {
        _subscriptionRepository = subscriptionRepository;
        _mapper = mapper;
        _itUserIdentityService = itUserIdentityService;
        _userHttpService = userHttpService;
    }

    public async Task<ResultContainer<SubscribeResponseDto>> Subscribe(SubscribeRequestDto data)
    {
        var result = new ResultContainer<SubscribeResponseDto>();
        var currentUserId = _itUserIdentityService.GetCurrentUserId();

        var subscriptionsAmount = await _subscriptionRepository.GetByFilter(p =>
            p.RespondentId == data.RespondentId && p.SubscriberId == currentUserId);

        if (data.RespondentId == currentUserId || subscriptionsAmount.Any())
        {
            result.ResponseStatusCode = ResponseStatusCode.BadRequest;
            return result;
        }

        var userExists = await _userHttpService.DoesUserExist(data.RespondentId);

        switch (userExists)
        {
            case null:
                result.ResponseStatusCode = ResponseStatusCode.ServiceUnavailable;
                return result;
            case false:
                result.ResponseStatusCode = ResponseStatusCode.NotFound;
                return result;
        }

        var subscription = new SubscriptionModel()
        {
            RespondentId = data.RespondentId,
            SubscriberId = currentUserId
        };

        await _subscriptionRepository.Create(subscription);

        result = _mapper.Map<ResultContainer<SubscribeResponseDto>>(subscription);

        result.ResponseStatusCode = ResponseStatusCode.Ok;

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