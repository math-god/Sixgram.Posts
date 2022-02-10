using AutoMapper;
using Post.Common.Response;
using Post.Common.Result;
using Post.Core.Dto.Membership;
using Post.Core.Membership;
using Post.Core.Token;
using Post.Database.EntityModels;
using Post.Database.Repository.Membership;
using Post.Database.Repository.Respondent;
using Post.Database.Repository.Subscriber;

namespace Post.Core.ControllerServices
{
    public class MembershipService : IMembershipService
    {
        private readonly IRespondentRepository _respondentRepository;
        private readonly ISubscriberRepository _subscriberRepository;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        private readonly IMembershipRepository _membershipRepository;

        public MembershipService
        (
            IMapper mapper,
            IRespondentRepository respondentRepository,
            ISubscriberRepository subscriberRepository,
            ITokenService tokenService,
            IMembershipRepository membershipRepository
        )
        {
            _respondentRepository = respondentRepository;
            _subscriberRepository = subscriberRepository;
            _mapper = mapper;
            _tokenService = tokenService;
            _membershipRepository = membershipRepository;
        }

        public async Task<ResultContainer<MembershipResponseDto>> Subscribe(MembershipRequestDto membership)
        {
            var result = new ResultContainer<MembershipResponseDto>();
            var currentUserId = _tokenService.GetCurrentUserId();

            var respondentMember = await _membershipRepository.GetById(membership.RespondentId);
            var subscriberMember = await _membershipRepository.GetById(currentUserId);

            if (respondentMember == null)
            {
                result.ErrorType = ErrorType.NotFound;
                return result;
            }

            var subscriber = await _subscriberRepository.GetById(subscriberMember.Id);
            var respondent = await _respondentRepository.GetById(respondentMember.Id);
            
            if (respondentMember.Id == subscriberMember.Id || subscriber != null || respondent != null)
            {
                result.ErrorType = ErrorType.BadRequest;
                return result;
            }

            var newSubscriber = new SubscriberModel()
            {
                Id = subscriberMember.Id,
                MemberId = respondentMember.Id
            };

            var newRespondent = new RespondentModel()
            {
                Id = respondentMember.Id,
                MemberId = subscriberMember.Id
            };

            await _subscriberRepository.Create(newSubscriber);
            await _respondentRepository.Create(newRespondent);

            return result;
        }

        public async Task<ResultContainer<MembershipResponseDto>> Unsubscribe(MembershipRequestDto membership)
        {
            var result = new ResultContainer<MembershipResponseDto>();
            var currentUserId = _tokenService.GetCurrentUserId();

            var respondent = await _respondentRepository.GetById(membership.RespondentId);
            var subscriber = await _subscriberRepository.GetById(currentUserId);

            if (respondent == null)
            {
                result.ErrorType = ErrorType.NotFound;
                return result;
            }

            if (respondent.Id == subscriber.Id)
            {
                result.ErrorType = ErrorType.BadRequest;
                return result;
            }
            
            await _subscriberRepository.Delete(subscriber);
            await _respondentRepository.Delete(respondent);

            return result;
        }

        public async Task<ResultContainer<UserDto>> CreateMember()
        {
            var result = new ResultContainer<UserDto>();

            var userId = _tokenService.GetCurrentUserId();
            var user = await _membershipRepository.GetById(userId);
            
            if (userId == user.Id)
            {
                result.ErrorType = ErrorType.BadRequest;
                return result;
            }
            
            var member = new MembershipModel()
            {
                Id = userId
            };

            await _membershipRepository.Create(member);

            return result;
        }
    }
}