using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDevDataBase.Entities
{
    public class TaskEntity
    {
        public Guid id { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime DateFinish { get; set; }
        public string Description { get; set; } = string.Empty;
        public Guid idDiscipline { get; set; }
        public Guid idGroup { get; set; }
        public Guid idTeacher { get; set; }
    }
}
