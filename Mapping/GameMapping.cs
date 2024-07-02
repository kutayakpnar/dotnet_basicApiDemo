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

    public static GameDto ToDto(this Game game){
        return  new GameDto(
                game.Id,
                game.Name,
                game.Genre!.Name, // ı assure it cannot be null
                game.Price,
                game.ReleaseDate

            );
    }

}
