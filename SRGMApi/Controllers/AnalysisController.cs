using Microsoft.AspNetCore.Mvc;
using SRGMApi.Services;

namespace SRGMApi.Controllers
{
    [ApiController]
    [Route("analysis")]
    public class AnalysisController(IGithubService githubService, IFileService fileService)
        : ControllerBase
    {
        [HttpGet("run")]
        public async Task<IActionResult> Run()
        {
            var data = await githubService.GetCumulativeIssuesAsync();
            await fileService.WriteListToFileAsync(data, "AccumulatedIssues.txt");
            return Ok();
        }
    }
}
