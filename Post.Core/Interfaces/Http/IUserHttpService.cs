namespace Post.Core.Interfaces.Http;

public interface IUserHttpService
{
    Task<bool?> DoesUserExist(Guid userId);
}