using Lab2.Exercises.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.ExercisesRegister
{
    class DogsRegister
    {
        private List<Dog> AllDogs;
        public DogsRegister()
        {
            AllDogs = new List<Dog>();
        }
        public DogsRegister(List<Dog> Dogs)
        {
            AllDogs = new List<Dog>();
            foreach(Dog dog in Dogs)
            {
                this.AllDogs.Add(dog);
            }
        }
        public void Add(Dog dog)
        {
            AllDogs.Add(dog);
        }
        public int DogsCount()
        {
            return this.AllDogs.Count;
        }
        public Dog GetDog(int index)
        {
            return AllDogs[index];
        }
        public int CountByGender(Gender gender)
        {
            int count = 0;
            foreach (Dog dog in this.AllDogs)
            {
                if (dog.Gender.Equals(gender))
                    count++;
            }
            return count;
        }
        public Dog FindOlderDog()
        {
            Dog oldest = AllDogs[0];
            foreach(Dog dog in this.AllDogs)
            {
                if(oldest.BirthDate.CompareTo(dog.BirthDate) > 0)
                    oldest = dog;
            }
            return oldest;
        }
        public List<string> FindBreeds()
        {
            List<string> Breeds = new List<string>();
            foreach (Dog dog in this.AllDogs)
            {
                string breed = dog.Breed;
                if (!Breeds.Contains(breed))
                {
                    Breeds.Add(breed);
                }
            }
            return Breeds;
        }
        public List<Dog> FilterByBreed(string breed)
        {
            List<Dog> Filtered = new List<Dog>();
            foreach (Dog dog in this.AllDogs)
            {
                if (dog.Breed.Equals(breed))
                {
                    Filtered.Add(dog);
                }
            }
            return Filtered;
        }
        public Dog FindOldestDog()
        {
            return this.FindOldestDog(this.AllDogs);
        }
        public Dog FindOldestDog(string breed)
        {
            List<Dog> Filtered = this.FilterByBreed(breed);
            return this.FindOldestDog(Filtered);
        }
        private Dog FindOldestDog(List<Dog> Dogs)
        {
            Dog oldest = Dogs[0];
            for(int i = 1; i < Dogs.Count; i++)
            {
                if(DateTime.Compare(oldest.BirthDate, Dogs[i].BirthDate) > 0)
                oldest = Dogs[i];
            }
            return oldest;
        }
        private Dog FindDogByID(int id)
        {
            foreach(Dog dog in this.AllDogs)
            {
                if(dog.ID == id)
                {
                    return dog;
                }
            }
            return null;
        }
        public void UpdateVaccinationInfo(List<Vaccination> vaccinations)
        {
            foreach(Vaccination vacc in vaccinations)
            {
                Dog dog = this.FindDogByID(vacc.DogID);
                if (dog == null)
                {
                    continue;
                }
                if(vacc > dog.LastVaccinationDate)
                {
                    dog.LastVaccinationDate = vacc.Date;
                }
            }
        }
        public List<Dog> FilterByVaccinationExpired(List<Vaccination> vaccinations)
        {
            List<Dog> expiredDogs = new List<Dog>();
            foreach (Dog dog in this.AllDogs)
            {           
                Vaccination dogVaccination = null;
                foreach (Vaccination vaccination in vaccinations)
                {
                    if (vaccination.DogID == dog.ID)
                    {
                        if (dogVaccination == null || vaccination > dog.LastVaccinationDate)
                        {
                            dogVaccination = vaccination;
                        }                        
                    }   
                }
                if (dogVaccination == null)
                {
                    expiredDogs.Add(dog);
                }
                else if(dogVaccination.Date.AddYears(1) < DateTime.Today)
                {
                    expiredDogs.Add(dog);
                }
            }
            return expiredDogs;
        }
        public bool Contains(Dog dog)
        {
            return AllDogs.Contains(dog);
        }
    }
}
