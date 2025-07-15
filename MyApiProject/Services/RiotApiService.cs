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
            var response = await _httpClient.GetAsync($"/lol/summoner/v4/summoners/by-puuid/{encryptedPUUID}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error getting summoner by PUUID: {ex.Message}");
        }
    }
}

//Learn more about dependency injection