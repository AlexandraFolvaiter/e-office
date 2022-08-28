using Newtonsoft.Json;

namespace eOffice.Services.Implementations;

public class CustomHttpClient
{
    private readonly HttpClient _httpClient;

    public CustomHttpClient()
    {
        _httpClient = new HttpClient();
    }

    public async Task<T> Get<T>(string url)
    {
        var response = await _httpClient.GetAsync(url);
        var responseBody = await response.Content.ReadAsStringAsync();

        var result = JsonConvert.DeserializeObject<T>(responseBody);

        return result;
    }

    public Task Post<T>(string url, T model)
    {
        var json = JsonConvert.SerializeObject(model);

        var httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

        return _httpClient.PostAsync(url, httpContent);
    }

    public Task Patch<T>(string url, T model)
    {
        var json = JsonConvert.SerializeObject(model);

        var httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

        return _httpClient.PatchAsync(url, httpContent);
    }
}