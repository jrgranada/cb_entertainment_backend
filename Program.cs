using CbEntertainmentBackend.src.Application;
using CbEntertainmentBackend.src.Application.Interface;
using CbEntertainmentBackend.src.Utils;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("*");
                      });
});

builder.Host.ConfigureAppSettings();

builder.Services.AddControllers();
builder.Services.AddScoped<IAuthWithSpotify, AuthWithSpotify>();
builder.Services.AddScoped<ISpotifyRequest, SpotifyRequest>();

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