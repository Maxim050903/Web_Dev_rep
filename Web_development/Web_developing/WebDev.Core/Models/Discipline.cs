using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDev.Core.Models
{
    public class Discipline
    {
        public Guid id { get; }
        public string Name { get; } = string.Empty;
        public Guid idTeacher { get; }
        public Guid idGroup { get; }

        private Discipline(Guid id, string Name
            , Guid idTeacher, Guid idGroup)
        {
            this.id = id;
            this.Name = Name;
            this.idTeacher = idTeacher;
            this.idGroup = idGroup;
        }

        public static (Discipline discipline, string Error) CreateDiscipline(Guid id, string Name
            , Guid idTeacher, Guid idGroup)
        {
            var Error = string.Empty;

            if (string.IsNullOrEmpty(Name))
            {
                Error = "Ошибка введите корректное наименование";
            }

            var discipline= new Discipline(id, Name, idTeacher, idGroup);

            return (discipline, Error);
        }

    }
}
