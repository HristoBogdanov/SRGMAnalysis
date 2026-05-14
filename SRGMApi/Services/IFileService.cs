namespace SRGMApi.Services
{
    public interface IFileService
    {
        Task WriteListToFileAsync<T>(List<T> items, string fileName);
    }
}
