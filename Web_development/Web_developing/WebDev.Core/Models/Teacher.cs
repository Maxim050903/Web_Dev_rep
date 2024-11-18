using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace WebDev.Core.Models
{
    public class Teacher
    {
        public Guid id { get; }
        public string Name { get; } = string.Empty;
        public string SecondName { get; } = string.Empty;
        public ulong IndividualNumber { get; }
        public string Password { get; } = string.Empty;

        public Teacher(Guid id,string Name
            ,string SecondName,ulong IndividualNumber
            ,string Password)
        {
            this.id = id;
            this.Name = Name;
            this.SecondName = SecondName;   
            this.IndividualNumber = IndividualNumber;
            this.Password = Password;
        }

        public static (Teacher teacher,string error) CreateTeacher(Guid id,string Name
            ,string SecondName,ulong IndividualNumber
            ,string Password)
        {
            var error = string.Empty;

            if (string.IsNullOrEmpty(Name))
            {
                error = "Введите какое-то имя";
            }

            var teacher = new Teacher(id,Name, SecondName, IndividualNumber,Password);

            return (teacher, error);
        }
    }
}
