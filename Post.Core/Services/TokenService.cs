using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
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

    public Guid? GetCurrentUserId() =>
        Guid.TryParse(_httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier), out var userId) 
            ? userId : null;

    public string GetClaim(string token, string claimType)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var securityToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

        var stringClaimValue = securityToken.Claims.First(claim => claim.Type == claimType).Value;
        return stringClaimValue;
    }
}