using GameProject.Data;
using GameProject.Dtos;
using GameProject.Entities;
using GameProject.Mapping;

namespace GameProject.Endpoints;

public static class GamesEndpoints
{
    private static readonly List<GameSummaryDto> games = [
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

    public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
    {

        var group=app.MapGroup("games").WithParameterValidation();

        // GET /games
        group.MapGet("/", () => games);

        //Get game by its id
        group.MapGet("/{id}", (int id,GameStoreContext dbContext) =>
        {

            //GameDto? game = games.Find(game => game.Id == id); change this to below for db operations
            Game? game=dbContext.Games.Find(id);


            return game is null ? Results.NotFound() : Results.Ok(game);


        }).WithName("getGame");

        //POST  /games
        group.MapPost("/", (createGameDto newGame,GameStoreContext dbContext) =>
        {
            

            Game game = newGame.ToEntity();
            game.Genre=dbContext.Genres.Find(newGame.GenreId);


            dbContext.Games.Add(game);
            dbContext.SaveChanges();

            //GameDto gameDto = game.ToDto();

               
            



            return Results.CreatedAtRoute("getGame", new { id = game.Id }, 
            game.ToGameDetailsDto());

        });

        //Update
        group.MapPut("/{id}", (int id, UpdateGameDto updatedGame) =>
        {
            var index = games.FindIndex(game => game.Id == id);
            games[index] = new GameSummaryDto(
                id,
                updatedGame.Name,
                updatedGame.Genre,
                updatedGame.price,
                updatedGame.ReleaseDate
            );

            return Results.NoContent();


        });

        //Delete
        group.MapDelete("/{id}", (int id) =>
        {
            var index = games.FindIndex(game => game.Id == id);

            games.Remove(games[index]);

            return Results.NoContent();



        });

        return group;



    }

}
