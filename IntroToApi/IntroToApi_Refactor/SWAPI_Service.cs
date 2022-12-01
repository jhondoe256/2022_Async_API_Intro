
using Newtonsoft.Json;

public class SWAPI_Service
{
    private readonly HttpClient _client = new HttpClient();


    //Async methods
    public async Task<Person> GetPersonAsync(string url)
    {
        HttpResponseMessage response = await _client.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var person = JsonConvert.DeserializeObject<Person>(content);
            return person;
        }
        return null;
    }

    public async Task<Vehicle> GetVehicleAsync(string url)
    {
        var response = await _client.GetAsync(url);
        return (response.IsSuccessStatusCode)
                ? await response.Content.ReadAsAsync<Vehicle>()
                : null;
    }

    public async Task<T> GetAsync<T>(string url) where T : class
    {
        var response = await _client.GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var obj = JsonConvert.DeserializeObject<T>(content);
            return obj;
        }
        return default;
    }

    public async Task<SearchResult<Person>> GetSearchPersonAsync(string query)
    {
        var response = await _client.GetAsync("https://swapi.dev/api/people?search=" + query);
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var searchResult = JsonConvert.DeserializeObject<SearchResult<Person>>(content);
            return searchResult;
        }
        return null;
    }

    public async Task<SearchResult<T>> GetSearchResultAsync<T>(string query, string category) where T : class
    {
        var response = await _client.GetAsync($"https://swapi.dev/api/{category}?search={query}");
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var searchResult = JsonConvert.DeserializeObject<SearchResult<T>>(content);
            return searchResult;
        }
        return null;
    }
}
