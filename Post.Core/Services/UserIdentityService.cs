using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Post.Core.Interfaces.User;

namespace Post.Core.Services;

public class UserIdentityService : IUserIdentityService
{
    private readonly HttpContext _httpContext;

    public UserIdentityService
    (
        IHttpContextAccessor httpContextAccessor
    )
    {
        _httpContext = httpContextAccessor.HttpContext;
    }

    public Guid GetCurrentUserId() =>
        Guid.TryParse(_httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier), out var userId)
            ? userId
            : new Guid();

    public string GetClaim(string token, string claimType)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var securityToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

        var stringClaimValue = securityToken.Claims.First(claim => claim.Type == claimType).Value;
        return stringClaimValue;
    }
}