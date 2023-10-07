using ScreenSound3.Database;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSingleton<ConnectionFactory>();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<AlbumDao>();
builder.Services.AddScoped<MusicasDao>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseFileServer();

app.MapControllers();

app.Run();
