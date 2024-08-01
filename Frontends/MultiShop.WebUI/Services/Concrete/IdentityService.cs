using IdentityModel.Client;
using Microsoft.Extensions.Options;
using MultiShop.DtoLayer.IdentityDtos.LoginDtos;
using MultiShop.WebUI.Services.Interfaces;
using MultiShop.WebUI.Settings;

namespace MultiShop.WebUI.Services.Concrete
{
    public class IdentityService : IIdentityService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ClientSettings _clientSettings;

        public IdentityService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor, IOptions<ClientSettings> clientSettings)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
            _clientSettings = clientSettings.Value;
        }

        public async Task<bool> SignIn(SignInDto signInDto)
        {
            var discoveryEndPoint = await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
            {
                Address = "http://localhost:5001",
                Policy = new DiscoveryPolicy
                {
                    RequireHttps=false
                }
            });
            var passwordTokenRequest = new PasswordTokenRequest
            {
                ClientId = _clientSettings.MultiShopManagerClient.ClientId,
                ClientSecret = _clientSettings.MultiShopManagerClient.ClientSecret,
                UserName = signInDto.Username,
                Password = signInDto.Password,
                Address = discoveryEndPoint.TokenEndpoint
            };
        }
    }
}