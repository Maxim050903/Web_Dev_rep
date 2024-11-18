using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDev.Core.Models
{
    public class _Task
    {
        public Guid id { get; }
        public DateTime DateCreate { get; }
        public DateTime DateFinish { get; }
        public string Description { get; } = string.Empty;
        public Guid idDiscipline { get; }
        public Guid idGroup { get; }
        public Guid idTeacher { get; }

        private _Task(Guid id, DateTime DateCreate
            , DateTime DateFinish, string Description
            , Guid idDiscipline, Guid idGroup
            , Guid idTeacher)
        {
            this.id = id;
            this.DateCreate = DateCreate;
            this.DateFinish = DateFinish;
            this.Description = Description;
            this.idDiscipline = idDiscipline;
            this.idGroup = idGroup;
            this.idTeacher = idTeacher;
        }

        public static (_Task task, string Error) CreateTask(Guid id,
            DateTime DateCreate, DateTime DateFinish
            , string Description, Guid idDiscipline
            , Guid idGroup, Guid idTeacher)
        {
            var Error = string.Empty;

            if (string.IsNullOrEmpty(Description))
            {
                Error = "Ошибка введите корректное описание";
            }

            var discipline = new _Task(id,DateCreate, DateFinish,Description,idDiscipline,idGroup,idTeacher);

            return (discipline, Error);
        }
    }
}
