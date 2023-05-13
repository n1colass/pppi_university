namespace RestAPI.Services.Journals
{
    public interface IJournals
    {
        Task<T?> GetAsync<T>(object? param);
        Task<T?> PostAsync<T>(object param);
        Task<T?> PutAsync<T>(object param);
        Task<T?> DeleteAsync<T>(object param);
    }
}
