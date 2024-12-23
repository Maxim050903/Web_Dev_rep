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
        public List<Guid> idGroups { get; }

        private Discipline(Guid id, string Name
            , Guid idTeacher, List<Guid> idGroups)
        {
            this.id = id;
            this.Name = Name;
            this.idTeacher = idTeacher;
            this.idGroups = idGroups;
        }

        public static (Discipline discipline, string Error) CreateDiscipline(Guid id, string Name
            , Guid idTeacher, List<Guid> idGroups)
        {
            var Error = string.Empty;

            if (string.IsNullOrEmpty(Name))
            {
                Error = "Ошибка введите корректное наименование";
            }

            var discipline= new Discipline(id, Name, idTeacher, idGroups);

            return (discipline, Error);
        }

    }
}
