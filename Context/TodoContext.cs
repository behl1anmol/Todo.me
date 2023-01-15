using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Todo.me.Model.DataTable;

namespace Todo.me.Context;
public class TodoContext : DbContext
{
    public TodoContext(DbContextOptions<TodoContext> options)
        :base(options)
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

    }

    public DbSet<TodoTable> Todos { get; set; }
    public DbSet<SprintTable> Sprints { get; set; }


}
