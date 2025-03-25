using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica.Classes
{
    internal class StudentClass
    {
        public void NewStudent(string name, string secondName, string lastName, int numberOfGroup, string description)
        {
            try
            {
                Student student = new Student
                {
                    Name = name,
                    LastName = lastName,
                    SecondName = secondName,
                    Id_Group = numberOfGroup,
                    Description = description
                };
                ConnectionClass connection = new ConnectionClass();
                connection.entities.Student.Add(student);
                connection.entities.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
