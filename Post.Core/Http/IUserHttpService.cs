namespace Post.Core.Http;

public interface IUserHttpService
{
    Task<bool?> DoesUserExist(Guid userId);
}