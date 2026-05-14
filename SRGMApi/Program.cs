using SRGMApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddHttpClient<IGithubService, GitHubService>(c =>
{
    c.DefaultRequestHeaders.Add("User-Agent", "SRGMApi/1.0");
    c.DefaultRequestHeaders.Add("Accept", "application/vnd.github+json");
    c.DefaultRequestHeaders.Add("Authorization", "");
});
builder.Services.AddScoped<IFileService, FileService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
