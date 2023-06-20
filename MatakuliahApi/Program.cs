using MatakuliahApi.Models;
using MatakuliahApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(
        options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

builder.Services.Configure<MatakuliahDatabaseSettings>(
    builder.Configuration.GetSection("UasMatakuliahDatabase"));

builder.Services.AddSingleton<KelasService>();
builder.Services.AddSingleton<MapelService>();
builder.Services.AddSingleton<GuruService>();
builder.Services.AddSingleton<PersensiHarianGuruService>();
builder.Services.AddSingleton<PersensiMengajarService>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
