namespace Post.Core.Token
{
    public interface ITokenService
    {
        public Guid? GetCurrentUserId();
        public string GetClaim(string token, string claimType);
    }
}