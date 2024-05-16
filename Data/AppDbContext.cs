using Microsoft.EntityFrameworkCore;

namespace grpcGreeter.Data
{
    public class AppDbContext : DbContext
    {       
        protected readonly IConfiguration Configuration;
        public AppDbContext(IConfiguration configuration) 
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(Configuration.GetConnectionString("webApiDataBase"));
        }
        public DbSet<TodoItem> todoItems {get;set;}
    }   

}


