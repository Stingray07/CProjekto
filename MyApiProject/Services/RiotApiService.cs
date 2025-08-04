namespace MyApiProject.Services;
public class RiotApiService : IRiotApiService
{
    private readonly HttpClient _httpClient;

    public RiotApiService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("RiotApi");
    }

    public async Task<string> GetSummonerByPUUIDAsync(string encryptedPUUID)
    {
        try
        {

            // THERE IS NO PUUID BEING SENT SO RIOT RESPONDS WITH 403
            var url = $"/lol/summoner/v4/summoners/by-puuid/{encryptedPUUID}";
            Console.WriteLine($"Sending GET request to: {_httpClient.BaseAddress}{url}");
            Console.WriteLine($"Headers: {string.Join(", ", _httpClient.DefaultRequestHeaders.Select(h => $"{h.Key}: {string.Join(", ", h.Value)}"))}");
            
            var response = await _httpClient.GetAsync(url);
            Console.WriteLine($"Response Status: {response.StatusCode}");
            
            var content = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Response Content: {content}");
            
            return content;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            throw;
        }
    }

    public async Task<List<string>> GetChampionMasteryByPUUIDAsync(string encryptedPUUID)
    {
        try
        { 
            var url = $"/lol/champion-mastery/v4/champion-masteries/by-puuid/{encryptedPUUID}";
            Console.WriteLine($"Sending GET request to: {_httpClient.BaseAddress}{url}");
            Console.WriteLine($"Headers: {string.Join(", ", _httpClient.DefaultRequestHeaders.Select(h => $"{h.Key}: {string.Join(", ", h.Value)}"))}");
            
            var response = await _httpClient.GetAsync(url);
            Console.WriteLine($"Response Status: {response.StatusCode}");

            //read docs if what is being returned is a list
            
            var content = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Response Content: {content}");
            
            return content;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            throw;
        }
    }
}
