using SeriesDictionary.Application.Application;
using SeriesDictionary.Application.Interfaces.MovieInterface;
using SeriesDictionary.Application.Interfaces.SeriesInterfaces;
using SeriesDictionary.Application.Interfaces.SeriesInterfaces.SeriesDictionary.Application.Interfaces;
using SeriesDictionary.Application.Interfaces.WordEpisodeInterfaces;
using SeriesDictionary.Application.Services;
using SeriesDictionary.Persistence.Context;
using SeriesDictionary.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();

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

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
    });

builder.Services.AddApplicationService(builder.Configuration);

// Add services to the container.
// builder.Services.AddControllers(); // Bu satýr zaten yukarýda var, tekrarlamaya gerek yok

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();