namespace Post.Core.Dto.Membership
{
    public class MembershipDto
    {
        public List<Guid> Subscribers { get; set; }
        public List<Guid> Subscribes { get; set; }
    }
}