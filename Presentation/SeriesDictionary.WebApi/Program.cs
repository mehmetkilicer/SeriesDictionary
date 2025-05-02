using System.Reflection;
using System.Text;
using MediatR; // ✅ MediatR için namespace ekleyelim
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using SeriesDictionary.Application; // ✅ Doğru namespace'i ekleyelim
using SeriesDictionary.Application.Application;
using SeriesDictionary.Application.Interfaces.AppUserInterfaces;
using SeriesDictionary.Application.Interfaces.LogoutInterface;
using SeriesDictionary.Application.Interfaces.MovieInterface;
using SeriesDictionary.Application.Interfaces.SeriesInterfaces;
using SeriesDictionary.Application.Interfaces.SeriesInterfaces.SeriesDictionary.Application.Interfaces;
using SeriesDictionary.Application.Interfaces.WordCloudRepository;
using SeriesDictionary.Application.Interfaces.WordEpisodeInterfaces;
using SeriesDictionary.Application.Interfaces.WordInterfaces;
using SeriesDictionary.Application.Services;
using SeriesDictionary.Application.Tools;
using SeriesDictionary.Persistence.Context;
using SeriesDictionary.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.RequireHttpsMetadata = false;
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidAudience = JwtTokenDefaults.ValidAudience,
        ValidIssuer = JwtTokenDefaults.ValidIssuer,
        ClockSkew = TimeSpan.Zero,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key)),
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true
    };
});

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyHeader()
            .AllowAnyMethod()
            .SetIsOriginAllowed((host) => true)
            .AllowCredentials();
    });
});

builder.Services.AddScoped<DictionaryContext>();

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IWordEpisodeRepository, WordEpisodeRepository>();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<ISeriesRepository, SeriesRepository>();
builder.Services.AddScoped<IShowRepository, ShowRepository>();
builder.Services.AddScoped<IWordCloudRepository, WordCloudRepository>();
builder.Services.AddScoped<IWordRepository, WordRepository>();
builder.Services.AddScoped<IAppUserRepository, AppUserRepository>();
builder.Services.AddScoped<ILogoutRepository, LogoutRepository>();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
    });

builder.Services.AddApplicationService(builder.Configuration);

// ✅ MediatR servisini ekleyelim
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null; // PascalCase'i koru
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
