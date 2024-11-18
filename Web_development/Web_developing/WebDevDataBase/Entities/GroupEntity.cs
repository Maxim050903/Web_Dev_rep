using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDevDataBase.Entities
{
    public class GroupEntity
    {
        public Guid id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<Guid> id_Students { get; set; }
    }
}
