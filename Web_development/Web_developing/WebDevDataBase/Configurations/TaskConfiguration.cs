using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebDevDataBase.Entities;

namespace WebDevDataBase.Configurations
{
    public class TaskConfiguration: IEntityTypeConfiguration<TaskEntity>
    {
        public void Configure(EntityTypeBuilder<TaskEntity> builder)
        {
            builder.HasKey(x => x.id);

            builder.Property(b => b.Description).IsRequired();
        }
    }
}
