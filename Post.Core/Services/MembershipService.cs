using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Post.Common.Response;
using Post.Common.Result;
using Post.Core.Dto.Membership;
using Post.Core.Dto.Subscription;
using Post.Core.Membership;
using Post.Database.EntityModels;
using Post.Database.Repository.Membership;

namespace Post.Core.Services
{
    public class MembershipService : IMembershipService
    {
        /*private readonly ITokenService _tokenService;*/
        private readonly IMembershipRepository _membershipRepository;
        private readonly IMapper _mapper;

        public MembershipService
        (
            /*ITokenService tokenService,*/
            IMapper mapper,
            IMembershipRepository membershipRepository
        )
        {
            /*_tokenService = tokenService;*/
            _mapper = mapper;
            _membershipRepository = membershipRepository;
        }
        
        
        
        public async Task<ResultContainer<MembershipResponseDto>> Subscribe(MembershipRequestDto membership)
        {
            var result = new ResultContainer<MembershipResponseDto>();

            var respondent = await _membershipRepository.GetById(membership.RespondentId);
            var subscriber = await _membershipRepository.GetById(membership.SubscriberId);

            if (respondent.Subscribers.Contains(membership.SubscriberId))
            {
                result.ErrorType = ErrorType.BadRequest;
                return result;
            }

            respondent.Subscribers.Add(membership.SubscriberId);
            subscriber.Subscriptions.Add(membership.RespondentId);

            await _membershipRepository.Update(respondent);
            await _membershipRepository.Update(subscriber);
            
            result = _mapper.Map<ResultContainer<MembershipResponseDto>>(membership);

            return result;
        }

        public async Task<ResultContainer<MembershipResponseDto>> Unsubscribe(MembershipRequestDto membership)
        {
            var result = new ResultContainer<MembershipResponseDto>();

            var respondent = await _membershipRepository.GetById(membership.RespondentId);
            var subscriber = await _membershipRepository.GetById(membership.SubscriberId);

            if (!respondent.Subscribers.Contains(membership.SubscriberId))
            {
                result.ErrorType = ErrorType.BadRequest;
                return result;
            }

            respondent.Subscribers.Remove(membership.SubscriberId);
            subscriber.Subscriptions.Remove(membership.RespondentId);

            await _membershipRepository.Update(respondent);
            await _membershipRepository.Update(subscriber);
            
            result = _mapper.Map<ResultContainer<MembershipResponseDto>>(membership);

            return result;
        }
    }
}