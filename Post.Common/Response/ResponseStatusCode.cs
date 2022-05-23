namespace Post.Common.Response;

public enum ResponseStatusCode
{
    Ok = 200,
    Created = 201,
    NoContent = 204,
    BadRequest = 400,
    Unauthorized = 401,
    Forbidden = 403,
    NotFound = 404,
    ServiceUnavailable = 503
}