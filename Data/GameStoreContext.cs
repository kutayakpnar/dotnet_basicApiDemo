using GameProject.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameProject.Data;

public class GameStoreContext(DbContextOptions<GameStoreContext> options) :DbContext(options)
{
    public DbSet<Game> Games => Set<Game>(); //Create db set instance

    public DbSet<Genre> Genres => Set<Genre>();
    

}
