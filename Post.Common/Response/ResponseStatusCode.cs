namespace Post.Common.Response;

public enum ResponseStatusCode
{
    Ok = 200,
    NoContent = 204,
    BadRequest = 400,
    Unauthorized = 401,
    NotFound = 404,
    ServiceUnavailable = 503
}