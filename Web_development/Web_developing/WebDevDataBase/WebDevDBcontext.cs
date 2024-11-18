using Microsoft.EntityFrameworkCore;
using WebDevDataBase.Entities;

namespace WebDevDataBase
{
    public class WebDevDBcontext:DbContext
    {
        public WebDevDBcontext(DbContextOptions<WebDevDBcontext> options)
            : base(options) 
        {
        }
        public DbSet<StudentEntity> Students { get; set; }
        public DbSet<TeacherEntity> Teachers { get; set; }
        public DbSet<TaskEntity> Tasks { get; set; }
        public DbSet<GroupEntity> Groups { get; set; }
        public DbSet<DisciplineEntity> Disciplines { get; set; }
    }
}
