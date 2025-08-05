using System.Text.Json;
using PicoGK;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapPost("/generate", (GenerateRequest req) =>
{
    Directory.CreateDirectory("output");
    var outPath = Path.Combine("output", $"{Guid.NewGuid()}.stl");
    Library.BuildMesh(req.Type, req.Params.GetRawText(), outPath);
    var bytes = File.ReadAllBytes(outPath);
    return Results.File(bytes, "application/sla");
});

app.Run();

record GenerateRequest(string Type, JsonElement Params);
