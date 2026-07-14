using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Scalar.AspNetCore;
using src.Data;
using src.Data.Interfaces;
using src.Data.Repositories;
using src.Services;
using src.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("Default"),
        o => o.UseNetTopologySuite()
));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<ICompanyService, CompanyService>();

builder.Services.AddScoped<IJobRepository, JobRepository>();
builder.Services.AddScoped<IJobService, JobService>();

builder.Services.AddScoped<ISkillRepository, SkillRepository>();
builder.Services.AddScoped<ISkillService, SkillService>();

builder.Services.AddScoped<IUserSkillRepository, UserSkillRepository>();
builder.Services.AddScoped<IUserSkillService, UserSkillService>();

builder.Services.AddScoped<IJobSkillRepository, JobSkillRepository>();
builder.Services.AddScoped<IJobSkillService, JobSkillService>();

builder.Services.AddScoped<IApplicationRepository, ApplicationRepository>();
builder.Services.AddScoped<IApplicationService, ApplicationService>();

builder.Services.AddScoped<IFavoriteJobRepository, FavoriteJobRepository>();
builder.Services.AddScoped<IFavoriteJobService, FavoriteJobService>();

builder.Services.AddScoped<ISearchHistoryRepository, SearchHistoryRepository>();
builder.Services.AddScoped<ISearchHistoryService, SearchHistoryService>();

builder.Services.AddScoped<IJobMatchRepository, JobMatchRepository>();
builder.Services.AddScoped<IJobMatchService, JobMatchService>();

builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddScoped<ILocationService, LocationService>();

var app = builder.Build();

app.UseExceptionHandler(appError =>
{
    appError.Run(async context =>
    {
        var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;

        context.Response.ContentType = "application/json";

        context.Response.StatusCode = exception switch
        {
            ArgumentException => StatusCodes.Status400BadRequest,
            KeyNotFoundException => StatusCodes.Status404NotFound,
            _ => StatusCodes.Status500InternalServerError
        };

        // var response = new { error = exception?.Message ?? "Erro interno do servidor." };
        var response = new { error = exception?.InnerException?.Message ?? exception?.Message ?? "Erro interno do servidor." };
        await context.Response.WriteAsJsonAsync(response);
    });
});

app.MapOpenApi();
app.MapScalarApiReference(options =>
    {
        options.Title = "metvagas";
        options.Theme = ScalarTheme.Default;
    });

app.MapGet("/", () => Results.Redirect("/scalar/v1"));

app.UseAuthorization();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.OpenConnection();
    ((Npgsql.NpgsqlConnection)db.Database.GetDbConnection()).ReloadTypes();
}

app.Run();

