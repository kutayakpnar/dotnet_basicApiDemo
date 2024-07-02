using GameProject.Data;
using GameProject.Dtos;
using GameProject.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var connString=builder.Configuration.GetConnectionString("GameStore");
builder.Services.AddSqlite<GameStoreContext>(connString);

var app = builder.Build();
// app is a host that listening our http requests





app.MapGamesEndpoints();

app.Run();
