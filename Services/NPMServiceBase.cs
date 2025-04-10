using System.Text;
using Newtonsoft.Json;

namespace NginxProxyManager.SDK.Services
{
    public abstract class NPMServiceBase
    {
        protected readonly HttpClient _httpClient;
        protected readonly string _baseUrl;

        protected NPMServiceBase(HttpClient httpClient, string baseUrl)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _baseUrl = baseUrl?.TrimEnd('/') ?? throw new ArgumentNullException(nameof(baseUrl));
        }

        protected async Task<T> SendAsync<T>(HttpRequestMessage request, CancellationToken cancellationToken = default)
        {
            using var response = await _httpClient.SendAsync(request, cancellationToken);
            var content = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<T>(content);
            }

            throw new HttpRequestException($"Error: {response.StatusCode} - {content}");
        }

        protected HttpRequestMessage CreateRequest(HttpMethod method, string path, object body = null)
        {
            var request = new HttpRequestMessage(method, $"{_baseUrl}/{path}");
            request.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            if (body != null)
            {
                var json = JsonConvert.SerializeObject(body);
                request.Content = new StringContent(json, Encoding.UTF8, "application/json");
            }

            return request;
        }
    }
} 