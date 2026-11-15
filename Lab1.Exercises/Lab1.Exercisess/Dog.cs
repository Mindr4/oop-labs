using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Exercisess
{
    class Dog
    {
        public int ID { set; get; }
        public string Name { set; get; }
        public string Breed { set; get; }
        public DateTime BirthDate { set; get; }
        public Gender Gender { set; get; }

        public Dog(int id, string name, string breed, DateTime birthdate, Gender gender)
        {
            this.ID = id;
            this.Name = name;
            this.Breed = breed;
            this.BirthDate = birthdate;
            this.Gender = gender;
        }
        public int CalculateAge()
        {
            DateTime today = DateTime.Today;
            int age = today.Year - this.BirthDate.Year;
            if(this.BirthDate.Date > today.AddYears(-age))
            {
                age--;
            }
            return age;
        }
    }  

} 
