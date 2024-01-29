using Microsoft.EntityFrameworkCore;

public class Context : DbContext
{
    public DbSet<Prioridades> prioridades { get; set; }

    public Context(DbContextOptions<Context> options) : base(options)
    {

    }

}