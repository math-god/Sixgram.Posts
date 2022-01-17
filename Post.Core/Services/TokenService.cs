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

    public string  GetClaim(string token, string claimType)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var securityToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

        var stringClaimValue = securityToken.Claims.First(claim => claim.Type == claimType).Value;
        return stringClaimValue;
    }
}