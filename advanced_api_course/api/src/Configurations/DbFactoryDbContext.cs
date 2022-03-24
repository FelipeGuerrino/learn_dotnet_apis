using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace src.Configurations
{
    public class DbFactoryDbContext : IDesignTimeDbContextFactory<CourseDbContext>
    {
        public CourseDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CourseDbContext>();
            optionsBuilder.UseSqlServer("Server=localhost;Database=COURSE;user=root;");

            CourseDbContext context = new CourseDbContext(optionsBuilder.Options);

            return context;
        }
    }
}