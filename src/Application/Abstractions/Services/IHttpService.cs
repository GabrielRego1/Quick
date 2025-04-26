namespace Application.Abstractions.Services;

public interface IHttpService
{
    Task<HttpResponseMessage> PostAsJsonAsync<T>(string url, T content, CancellationToken cancellationToken);
}