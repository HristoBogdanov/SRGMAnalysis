using SRGMApi.Models;

namespace SRGMApi.Services
{
    public interface IGithubService
    {
        Task<List<IssueDataPoint>> GetCumulativeIssuesAsync();
    }
}
