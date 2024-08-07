using APIWebGV.Data;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Ajoutez les services DbContext pour les deux contextes
builder.Services.AddDbContext<GaragesAPIDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("APIWebGVConnectionString")));

builder.Services.AddDbContext<VoituresAPIDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("APIWebGVConnectionString")));

// Ajouter des services au conteneur.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurer le pipeline de requêtes HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();

