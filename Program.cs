using GameProject.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
// app is a host that listening our http requests

List<GameDto> games = [
    new (1,
    "Game 1",
    "Fighting",
    19.99M,
    new DateOnly(1992,7,15)),
    new (2,
    "Game 2",
    "RolePlaying ",
    11.34M,
    new DateOnly(2010,9,30)),
    new (3,
    "Game 3",
    "Sports",
    14.59M,
    new DateOnly(2022,3,24))
   
];

// GET /games
app.MapGet("games",()=> games);

//Get game by its id
app.MapGet("getGamesById/{id}", (int id)=>{
    return games.Find(game => game.Id==id);
}).WithName("getGame");

//POST  /games
app.MapPost("games",(createGameDto newGame)=> {
    GameDto game= new (
        games.Count+1,
        newGame.Name,
        newGame.Genre,
        newGame.price,
        newGame.ReleaseDate

    );
    games.Add(game);

    return Results.CreatedAtRoute("getGame",new{id=game.Id},game);

});





app.Run();
