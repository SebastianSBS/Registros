using Microsoft.EntityFrameworkCore;

public class Context : DbContext
{
    public DbSet<Prioridades> prioridades { get; set; }
    public DbSet<Clientes> clientes {get; set;}
    public DbSet<Tickets> tickets {get; set;}
    public DbSet<Sistemas> sistemas {get; set;}
    public Context(DbContextOptions<Context> options) : base(options)
    {
        
    }

    

}