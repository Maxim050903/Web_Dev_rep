using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDevDataBase.Entities;

namespace WebDevDataBase.Configurations
{
    public class TeacherConfiguraton: IEntityTypeConfiguration<TeacherEntity>
    {
        public void Configure(EntityTypeBuilder<TeacherEntity> builder)
        {
            builder.HasKey(x => x.id);

            builder.Property(b => b.Name).IsRequired();
        }
    }
}
