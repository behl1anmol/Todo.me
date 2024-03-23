using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Todo.me.Context;
public class TodoContext : DbContext
{
    public TodoContext(DbContextOptions<TodoContext> options)
        : base(options)
    {
        SQLitePCL.Batteries_V2.Init();
        //this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        //this.ChangeTracker.LazyLoadingEnabled = false;
        this.Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlite($"Filename={Constants.DbPath}");
        optionsBuilder.LogTo(message => Debug.WriteLine(message), new[] {
            DbLoggerCategory.Database.Command.Name
        }, LogLevel.Information).EnableSensitiveDataLogging();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<TodoTable>()
            .HasKey(x => x.Id);

        modelBuilder.Entity<TodoTable>()
            .HasOne(x => x.Sprint)
            .WithMany()
            .HasForeignKey(x => x.SprintID);

        modelBuilder.Entity<SprintTable>()
            .HasKey(x => x.Id);
    }
    public DbSet<TodoTable> Todos
    {
        get; set;
    }
    public DbSet<SprintTable> Sprints
    {
        get; set;
    }


}
