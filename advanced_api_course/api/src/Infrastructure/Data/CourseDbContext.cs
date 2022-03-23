using Microsoft.EntityFrameworkCore;
using src.Infrastructure.Data.Mapping;

public class CourseDbContext : DbContext
{
    public CourseDbContext(DbContextOptions<CourseDbContext> options) :base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CourseMapping());
        modelBuilder.ApplyConfiguration(new StudentMapping());
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<User> User { get; set; }
}