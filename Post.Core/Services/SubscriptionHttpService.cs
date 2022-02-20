using System.Net.Http.Headers;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using Post.Common.Result;
using Post.Core.Dto.Subscription.User;
using Post.Core.Http;

namespace Post.Core.Services;

public class SubscriptionHttpService : ISubscriptionHttpService
{
    private readonly HttpClient _httpClient;
    private readonly HttpContext _httpContext;
    
    public SubscriptionHttpService
    (
        IHttpClientFactory httpClientFactory,
        IHttpContextAccessor httpContextAccessor
    )
    {
        _httpClient = httpClientFactory.CreateClient("auth");
        _httpContext = httpContextAccessor.HttpContext;
    }
    
    public async Task<bool> DoesUserExist(Guid userId)
    {
        _httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", await _httpContext.GetTokenAsync("access_token"));

        var responseMessage = await _httpClient.GetAsync($"/api/v1/user/{userId}");
        
        return responseMessage.IsSuccessStatusCode;
    }
}