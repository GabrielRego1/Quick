using System.Net.Http.Json;
using Application.Abstractions.Services;

namespace Application.Services.Http;

public class HttpService(HttpClient httpClient) : IHttpService
{
    public Task<HttpResponseMessage> PostAsJsonAsync<T>(string url, T content, CancellationToken cancellationToken)
        => httpClient.PostAsJsonAsync(url, content, cancellationToken);
}