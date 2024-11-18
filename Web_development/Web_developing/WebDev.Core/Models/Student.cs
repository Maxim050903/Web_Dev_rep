using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDev.Core.Models
{
    public class Student
    {
        public Guid id { get; }
        public string Name { get; } = string.Empty;
        public string SecondName { get; } = string.Empty;
        public string GroupName { get; } = string.Empty;
        public ulong IndividualNumber { get; }
        public string Password { get; } = string.Empty;
    
        private Student(Guid id,string Name
            ,string SecondName,string GroupName
            ,ulong IndividualNumber,string Password)
        {
            this.id = id;
            this.Name = Name;   
            this.SecondName = SecondName;
            this.GroupName = GroupName;
            this.IndividualNumber = IndividualNumber;
            this.Password = Password;
        }

        public static (Student student, string Error) CreateStudent (Guid id,string Name
            , string SecondName, string GroupName
            , ulong IndividualNumber, string Password)
        {
            var Error = string.Empty;

            if (string.IsNullOrEmpty(Name))
            {
                Error = "Ошибка введите имя";
            }

            var student = new Student(id, Name, SecondName, GroupName, IndividualNumber, Password);

            return (student, Error);
        }
    
    }
}
