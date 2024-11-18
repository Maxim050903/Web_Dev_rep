using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebDevDataBase.Entities;

namespace WebDevDataBase.Configurations
{
    public class DisciplineConfiguration: IEntityTypeConfiguration<DisciplineEntity>
    {
        public void Configure(EntityTypeBuilder<DisciplineEntity> builder)
        {
            builder.HasKey(x => x.id);

            builder.Property(b => b.Name).IsRequired();
        }
    }
}
