public interface IRiotApiService
{
    Task<string> GetSummonerByPUUIDAsync(string encryptedPUUID);
}