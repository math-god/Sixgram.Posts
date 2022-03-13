namespace Post.Core.Interfaces.User
{
    public interface IUserIdentityService
    {
        public Guid GetCurrentUserId();
        public string GetClaim(string token, string claimType);
    }
}