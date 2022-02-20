namespace Post.Core.Http;

public interface ISubscriptionHttpService
{
    Task<bool> DoesUserExist(Guid userId);
}