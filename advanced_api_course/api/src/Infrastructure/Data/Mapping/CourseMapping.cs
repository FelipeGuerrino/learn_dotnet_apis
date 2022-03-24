using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace src.Infrastructure.Data.Mapping
{
    public class CourseMapping : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("TB_COURSE");
            builder.HasKey(p => p.Code);
            builder.Property(p => p.Code).ValueGeneratedOnAdd();
            builder.Property(p => p.Description);
            builder.HasOne(p => p.User).WithMany().HasForeignKey(fk => fk.UserCode);
        }
    }
}