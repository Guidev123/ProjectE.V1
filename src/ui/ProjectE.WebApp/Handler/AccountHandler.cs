using ProjectE.Core.Commands.Account;
using ProjectE.Core.Handlers;
using ProjectE.Core.Responses;
using System.Net.Http.Json;
using System.Text;

namespace ProjectE.WebApp.Handler
{
    public class AccountHandler(IHttpClientFactory _httpClientFactory) : IAccountHandler
    {
        private readonly HttpClient _client = _httpClientFactory.CreateClient(WebConfiguration.HTTP_CLIENT_NAME);

        public async Task<Response<string>> LoginAsync(LoginCommand command)
        {
            var result = await _client.PostAsJsonAsync("api/identity/login?useCookies=true", command);
            return result.IsSuccessStatusCode ? new Response<string>("Login realizado!", 200, "Login realizado!") : new Response<string>(null, 400, "Usuario ou senha inválidos");
        }
        public async Task<Response<string>> RegisterAsync(RegisterCommand command)
        {
            var result = await _client.PostAsJsonAsync("api/custom-identity/register", command);
            return result.IsSuccessStatusCode ? new Response<string>("Cadastro realizado!", 201, "Cadastro realizado!") : new Response<string>(null, 400, "Não foi possivel criar sua conta");
        }
        public async Task LogoutAsync()
        {
            var emptyContent = new StringContent("{}", Encoding.UTF8, "application/json");
            await _client.PostAsJsonAsync("api/identity/logout", emptyContent);

        }
    }
}
