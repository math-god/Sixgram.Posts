using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Http;
using Post.Core.Token;

namespace Post.Core.Services;

public class TokenService : ITokenService
{
    private readonly HttpContext _httpContext;

    public TokenService
    (
        IHttpContextAccessor httpContextAccessor
    )
    {
        _httpContext = httpContextAccessor.HttpContext;
    }

    public Guid GetCurrentUserId()
    {
        
        var handler = new JwtSecurityTokenHandler();
        throw new NotImplementedException();
    }
}