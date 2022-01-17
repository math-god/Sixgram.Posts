namespace Post.Core.Token
{
    public interface ITokenService
    {
        public string GetClaim(string token, string claimType);
    }
}