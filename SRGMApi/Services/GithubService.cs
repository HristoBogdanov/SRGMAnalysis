using SRGMApi.Models;
using System.Text.Json.Nodes;

namespace SRGMApi.Services
{
    public class GitHubService(HttpClient http) : IGithubService
    {
        private const string RepoUrl = "https://api.github.com/repos/dotnet/runtime";

        public async Task<List<IssueDataPoint>> GetCumulativeIssuesAsync()
        {
            var issues = new List<DateTimeOffset>();
            var page = 1;
            var max_page = 20;

            while (page < max_page)
            {
                var url = $"{RepoUrl}/issues?state=all&per_page=100&page={page}";
                var response = await http.GetFromJsonAsync<JsonArray>(url);
                if (response is null || response.Count == 0) break;

                foreach (var issue in response)
                {
                    var created = issue!["created_at"]!.GetValue<DateTimeOffset>();
                    issues.Add(created);
                }
                page++;
            }

            var grouped = issues
                .GroupBy(d => d.Date)
                .OrderBy(g => g.Key)
                .ToList();

            var result = new List<IssueDataPoint>();
            int cumulative = 0;
            int t = 1;
            foreach (var group in grouped)
            {
                cumulative += group.Count();
                result.Add(new IssueDataPoint(t++, cumulative));
            }

            return result;
        }
    }
}
