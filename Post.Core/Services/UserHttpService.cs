using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Post.Core.Interfaces.Connection;
using Post.Core.Interfaces.Http;
using Post.Core.Options;

namespace Post.Core.Services;

public class UserHttpService : IUserHttpService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly HttpContext _httpContext;
    private readonly IConnectionService _connectionService;

    public UserHttpService
    (
        IHttpClientFactory httpClientFactory,
        IHttpContextAccessor httpContextAccessor,
        IConnectionService connectionService,
        BaseAddresses addresses
    )
    {
        _httpClientFactory = httpClientFactory;
        _httpContext = httpContextAccessor.HttpContext;
        _connectionService = connectionService;
    }

    public async Task<bool?> DoesUserExist(Guid userId)
    {
        using var client = _httpClientFactory.CreateClient("AuthService");

        client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", await _httpContext.GetTokenAsync("access_token"));

        /*if (!_connectionService.IsConnected("localhost", 5176)) return null;*/
        var responseMessage = await client.GetAsync($"{userId}");
        return responseMessage.IsSuccessStatusCode;
    }
}