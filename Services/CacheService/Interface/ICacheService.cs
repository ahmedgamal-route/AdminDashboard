namespace Services.CacheService.Interface
{
    public interface ICacheService
    {
        Task<string> SetCasheResponseAsync(string cashKey, object response, TimeSpan timeToLive);
        Task<string> GetCasheResponseAsync(string cashKey);

    }
}
