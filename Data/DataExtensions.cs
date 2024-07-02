using Microsoft.EntityFrameworkCore;

namespace GameProject.Data;

//for manage migrations when we run program it updates automatically
public static class DataExtensions
{   
    public static void MigrateDb(this WebApplication app){
        using var scope= app.Services.CreateScope();
        var dbContext=scope.ServiceProvider.GetRequiredService<GameStoreContext>();
        dbContext.Database.Migrate();
        
    }


}
