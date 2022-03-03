using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Post.Core.Http;

namespace Post.Core.Services;

public class UserHttpService : IUserHttpService
{
    private readonly HttpClient _httpClient;
    private readonly HttpContext _httpContext;
    
    public UserHttpService
    (
        IHttpClientFactory httpClientFactory,
        IHttpContextAccessor httpContextAccessor
    )
    {
        _httpClient = httpClientFactory.CreateClient("auth");
        _httpContext = httpContextAccessor.HttpContext;
    }
    
    public async Task<bool?> DoesUserExist(Guid userId)
    {
        _httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", await _httpContext.GetTokenAsync("access_token"));

        try
        {
            var responseMessage = await _httpClient.GetAsync($"/api/v1/user/{userId}");
            return responseMessage.IsSuccessStatusCode;
        }
        catch (HttpRequestException e)
        {
            return null;
        }
    }
}