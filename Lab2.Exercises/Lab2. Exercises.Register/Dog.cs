using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.ExercisesRegister
{
    class Dog
    {
        public int ID { set; get; }
        public string Name { set; get; }
        public string Breed { set; get; }
        public DateTime BirthDate { set; get; }
        public Gender Gender { set; get; }
        public DateTime LastVaccinationDate { set; get; }

        private const int VaccinationDuration = 1;

        public Dog(int id, string name, string breed, DateTime birthdate, Gender gender)
        {
            this.ID = id;
            this.Name = name;
            this.Breed = breed;
            this.BirthDate = birthdate;
            this.Gender = gender;
        }
        public int Age
        {
            get
            {
                DateTime today = DateTime.Today;
                int age = today.Year - this.BirthDate.Year;
                if (this.BirthDate.Date > today.AddYears(-age))
                {
                    age--;
                }
                return age;
            }
        }
        public bool RequiresVaccination
        {
            get
            {
                if (LastVaccinationDate.Equals(DateTime.MinValue))
                {
                    return true;
                }
                return LastVaccinationDate.AddYears(VaccinationDuration).CompareTo(DateTime.Now) < 0;
            }
        }
        public override bool Equals(object other)
        {
            return this.ID == ((Dog)other).ID;
        }
        public override int GetHashCode()
        {
            return this.ID.GetHashCode();
        }
    }  

} 
