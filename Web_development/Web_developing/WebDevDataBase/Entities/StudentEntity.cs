using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDevDataBase.Entities
{
    public class StudentEntity
    {
        public Guid id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string SecondName { get; set; } = string.Empty;
        public string GroupName { get; set; } = string.Empty;
        public ulong IndividualNumber { get; set; }
        public string Password { get; set; } = string.Empty;
    }
}
