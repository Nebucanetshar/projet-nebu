using Microsoft.EntityFrameworkCore;

namespace grpcGreeter.Data
{
    public class AppDbContext : DbContext
    {       
        public AppDbContext(DbContextOptions<AppDbContext> options ) : base( options )
        {

        }
        public DbSet<TodoItem> todoItems => Set<TodoItem>();
    }   

}


