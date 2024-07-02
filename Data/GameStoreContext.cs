using GameProject.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameProject.Data;

public class GameStoreContext(DbContextOptions<GameStoreContext> options) :DbContext(options)
{
    public DbSet<Game> Games => Set<Game>(); //Create db set instance

    public DbSet<Genre> Genres => Set<Genre>();


    //when migrations executes this code directly executes we can modify these according to our needs
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genre>().HasData(
            new {Id=1, Name="Fighting"},
            new {Id=2, Name="RolePlaying"},
            new {Id=3, Name="Sports"},
            new {Id=4, Name="Racing"},
            new {Id=5, Name="Kids and Family"}
        );
    }

}
