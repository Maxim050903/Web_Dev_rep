using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDev.Core.Models
{
    public class Group
    {
        public Guid id { get; }
        public string Name { get; }
        public List<Guid> id_Students { get; }


        private Group(Guid id, string Name, List<Guid> id_Students)
        {
            this.id = id;
            this.Name = Name;
            this.id_Students = id_Students;
        }

        public static (Group group, string error) CreateGroup(Guid id, string Name, List<Guid> id_Students)
        {
            var error = string.Empty;

            if (string.IsNullOrEmpty(Name))
            {
                error = "Введите корректное имя";
            }

            var group = new Group(id, Name, id_Students);

            return (group, error);
        }
    }
}
