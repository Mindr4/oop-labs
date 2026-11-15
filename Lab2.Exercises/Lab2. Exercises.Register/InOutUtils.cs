using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;
using Lab2.Exercises.Register;

namespace Lab2.ExercisesRegister
{
    static class InOutUtils
    {
        public static DogsRegister ReadDogs(string FileName)
        {
            DogsRegister Dogs = new DogsRegister();
            string[] Lines = File.ReadAllLines(FileName, Encoding.UTF8);
            foreach (string Line in Lines)
            {
                string[] Values = Line.Split(';');
                int id = int.Parse(Values[0]);
                string name = Values[1];
                string breed = Values[2];
                DateTime birthdate = DateTime.Parse(Values[3]);

                Gender gender;
                Enum.TryParse(Values[4], out gender);

                Dog dog = new Dog(id, name, breed, birthdate, gender);
                if (!Dogs.Contains(dog))
                {
                    Dogs.Add(dog);
                }
                
            }
            return Dogs;
        }
        public static void PrintDogs(DogsRegister Dogs)
        {
            Console.WriteLine(new string('-', 74));
            Console.WriteLine("| {0,8} | {1,-15} | {2,-15} | {3,-12} | {4,-8} |", "Reg Nr", "Vardas", "Veisle", "Gimimo Data", "Lytis");
            Console.WriteLine(new string('-', 74));
            for(int i = 0;i < Dogs.DogsCount();i++)
            {
                Console.WriteLine("| {0,8} | {1,-15} | {2,-15} | {3,-12:yyyy-MM-dd} | {4,-8} |", Dogs.GetDog(i).ID, Dogs.GetDog(i).Name, Dogs.GetDog(i).Breed, Dogs.GetDog(i).BirthDate, Dogs.GetDog(i).Gender);
            }
            Console.WriteLine(new string('-', 74));
        }
        public static void PrintBreeds(List<string> Breeds)
        {
            foreach (string breed in Breeds)
            {
                Console.WriteLine(breed);
            }
        }
        public static void PrintDogsToCSVFile(string fileName, List<Dog> Dogs)
        {
            string[] lines = new string[Dogs.Count + 1];
            lines[0] = String.Format("{0};{1};{2};{3};{4}",
                "Reg.Nr", "Vardas", "Veisle", "Gimimo data", "Lytis");
            for (int i = 0; i < Dogs.Count; i++)
            {
                lines[i + 1] = String.Format("{0};{1};{2};{3:yyyy-MM-dd};{4}",
                       Dogs[i].ID, Dogs[i].Name, Dogs[i].Breed, Dogs[i].BirthDate, Dogs[i].Gender);
            }
            File.WriteAllLines(fileName, lines, Encoding.UTF8);
        }
        public static List<Vaccination> ReadVaccinations(string fileName)
        {
            List<Vaccination> Vaccination = new List<Vaccination>();
            string[] lines = File.ReadAllLines(fileName);
            foreach(string line in lines)
            {
                string[] parts = line.Split(';');
                int DogID = int.Parse(parts[0]);
                DateTime VaccinationDate = DateTime.Parse(parts[1]);

                Vaccination v = new Vaccination(DogID, VaccinationDate);
                Vaccination.Add(v);
            }
            return Vaccination;
        }
    }
}
