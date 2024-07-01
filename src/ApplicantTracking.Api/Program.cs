using System;
using ApplicantTracking.Infrastructure.Database.Context;
using ApplicantTracking.Infrastructure.Database.Handler.Interfaces;
using ApplicantTracking.Infrastructure.Database.Handler;
using ApplicantTracking.Infrastructure.Repositories;
using ApplicantTracking.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x => {
    x.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo {
        Version = "v1",
        Title = "Applicant Tracking API"
    });
});

ConfigureServices();

var app = builder.Build();

//app.MapHealthChecks("/health");

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI(x => {
        x.SwaggerEndpoint("/swagger/v1/swagger.json", "ApplTrack");
    });
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

MigrateDatabase<ApplicantTrackingDbContext>();

app.Run();

void ConfigureServices()
{
    var connString = builder.Configuration.GetConnectionString("ApplicantTrackingDb");

    //builder.Services.AddDbContext<ApplicantTrackingDbContext>(options => options.UseSqlServer(connString));

    ConfigureInfrastructure();
}

void ConfigureInfrastructure()
{
    builder.Services.AddScoped<ICreateCandidatesHandler, CreateCandidatesHandler>();
    builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
    builder.Services.AddScoped<ICandidatesRepository, CandidatesRepository>();
    builder.Services.AddScoped<ITimelinesRepository, TimelinesRepository>();
}

void MigrateDatabase<T>() where T : DbContext
{
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        try
        {
            var db = services.GetRequiredService<T>();
            db.Database.Migrate();
        }
        catch (Exception ex)
        {
            var logger = services.GetRequiredService<ILogger<Program>>();
            logger.LogError(ex, "Ocorreu um erro durante a migração da base de dados.");
        }
    }
}
