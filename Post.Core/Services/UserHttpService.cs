using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Post.Core.Interfaces.Connection;
using Post.Core.Interfaces.Http;

namespace Post.Core.Services;

public class UserHttpService : IUserHttpService
{
    private readonly HttpClient _httpClient;
    private readonly HttpContext _httpContext;
    private readonly IConnectionService _connectionService;

    public UserHttpService
    (
        IHttpClientFactory httpClientFactory,
        IHttpContextAccessor httpContextAccessor,
        IConnectionService connectionService
    )
    {
        _httpClient = httpClientFactory.CreateClient("auth");
        _httpContext = httpContextAccessor.HttpContext;
        _connectionService = connectionService;
    }

    public async Task<bool?> DoesUserExist(Guid userId)
    {
        _httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", await _httpContext.GetTokenAsync("access_token"));


        if (!_connectionService.IsConnected("localhost", 5176)) return null;
        var responseMessage = await _httpClient.GetAsync($"/api/v1/user/{userId}");
        return responseMessage.IsSuccessStatusCode;
    }
}