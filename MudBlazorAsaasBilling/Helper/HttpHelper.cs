using MudBlazorAsaasBilling.Common;
using System.Net.Http.Headers;
using System.Text.Json;

namespace MudBlazorAsaasBilling.Helper
{
    public class HttpHelper
    {
        private readonly HttpClient _client;
        private readonly AsaasSettings _settings;

        public HttpHelper(HttpClient client, IConfiguration configuration)
        {
            _client = client;
            _settings = configuration.GetSection("AsaasSettings").Get<AsaasSettings>();
        }

        public async Task<T> SendRequestAsync<T>(HttpMethod method, string endpoint, object content = null)
        {
            var request = new HttpRequestMessage
            {
                Method = method,
                RequestUri = new Uri($"{_settings.BaseUrl}/{endpoint}"),
                Headers =
      {
          { "accept", "application/json" },
          { "access_token", _settings.AccessToken },
          { "User-Agent", _settings.UserAgent }
      }
            };

            if (content != null)
            {
                var jsonContent = JsonSerializer.Serialize(content);
                request.Content = new StringContent(jsonContent)
                {
                    Headers =
          {
              ContentType = new MediaTypeHeaderValue("application/json")
          }
                };
            }

            try
            {
                var response = await _client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<T>(responseBody);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request error: {e.Message}");
                throw;
            }
        }
    }
}
