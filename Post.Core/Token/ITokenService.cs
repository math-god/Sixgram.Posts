namespace Post.Core.Token
{
    public interface ITokenService
    {
        public Guid GetCurrentUserId();
    }
}