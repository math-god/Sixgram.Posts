using Microsoft.AspNetCore.Http;

namespace Post.Core.Extensions;

public static class HttpContextExtension
{
    public static string GetUserId(this HttpContext httpContext)
    {
        foreach (var item in httpContext.User.Claims)
        {
            Console.WriteLine(item);
        }
        return httpContext.User == null
            ? string.Empty
            : httpContext.User.Claims.Single(c => c.Type == "id").Value;
    }
}