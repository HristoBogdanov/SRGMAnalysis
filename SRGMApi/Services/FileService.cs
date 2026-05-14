
namespace SRGMApi.Services
{
    public class FileService : IFileService
    {
        public async Task WriteListToFileAsync<T>(List<T> items, string fileName)
        {
            string downloadsPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
            "Downloads",
            fileName);

            string content = "{" + string.Join(", ", items.Select(item => item?.ToString() ?? "null")) + "}";

            await File.WriteAllTextAsync(downloadsPath, content);
        }
    }
}
