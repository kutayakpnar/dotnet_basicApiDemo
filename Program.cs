using GameProject.Dtos;
using GameProject.Endpoints;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
// app is a host that listening our http requests





app.MapGamesEndpoints();

app.Run();
