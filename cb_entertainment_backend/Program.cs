using cb_entertainment_backend.DTOs;
using cb_entertainment_backend.Interfaces;
using cb_entertainment_backend.Services;
using cb_entertainment_backend.Validators;
using FluentValidation;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("*")
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                      });
});

// Add services to the container.
builder.Services.AddScoped<ISpotifyApiService, SpotifyApiService>();
builder.Services.AddScoped<ISpotifyAuthService, SpotifyAuthService>();

// Cliente HTTP
builder.Services.AddHttpClient<ISpotifyApiService, SpotifyApiService>(client =>
{
    var url = builder.Configuration[ key: "SpotifySettings:BaseUrl"] ?? "";
    client.BaseAddress = new Uri(url);
});
builder.Services.AddHttpClient<ISpotifyAuthService, SpotifyAuthService>();

// Validadores
builder.Services.AddScoped<IValidator<SearchRequestDto>, SearchRequestValidator>();

builder.Services.AddControllers();
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


app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
