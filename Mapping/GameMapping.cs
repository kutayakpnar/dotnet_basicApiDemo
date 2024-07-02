using GameProject.Entities;
using GameProject.Dtos;

namespace GameProject.Mapping;

public static class GameMapping
{

    public static Game ToEntity(this createGameDto game){
        return new Game(){
                Name=game.Name,
                
                GenreId=game.GenreId,
                Price=game.price,
                ReleaseDate=game.ReleaseDate
            };

    }

    public static GameSummaryDto ToDto(this Game game){
        return  new GameSummaryDto(
                game.Id,
                game.Name,
                game.Genre!.Name, // ı assure it cannot be null
                game.Price,
                game.ReleaseDate

            );
    }

     public static GameDetailsDto ToGameDetailsDto(this Game game){
        return  new GameDetailsDto(
                game.Id,
                game.Name,
                game.GenreId, // ı assure it cannot be null
                game.Price,
                game.ReleaseDate

            );
    }

}
