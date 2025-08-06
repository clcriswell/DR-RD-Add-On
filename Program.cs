using System;
using System.IO;
using System.Text.Json;
using PicoGK;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
