namespace MyApiProject.Services;
public interface IRiotApiService
{
    Task<string> GetSummonerByPUUIDAsync(string encryptedPUUID);
}