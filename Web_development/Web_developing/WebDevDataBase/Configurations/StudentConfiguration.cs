using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDevDataBase.Entities;

namespace WebDevDataBase.Configurations
{
    public class StudentConfiguration:IEntityTypeConfiguration<StudentEntity>
    {
        public void Configure(EntityTypeBuilder<StudentEntity> builder)
        {
            builder.HasKey(x => x.id);

            builder.Property(b => b.Name).IsRequired();
        }
    }
}
