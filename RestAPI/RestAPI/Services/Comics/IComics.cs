namespace RestAPI.Services.Comics
{
    public interface IComics
    {
        Task<T?> GetAsync<T>(object? param);
        Task<T?> PostAsync<T>(object param);
        Task<T?> PutAsync<T>(object param);
        Task<T?> DeleteAsync<T>(object param);
    }
}
