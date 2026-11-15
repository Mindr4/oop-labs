using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Exercisess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Dog> allDogs = InOutUtils.ReadDogs("AllDogs.txt");
            Console.WriteLine("Registro Informacija");
            InOutUtils.PrintDogs(allDogs);

            Console.WriteLine("Is viso sunu: {0}", allDogs.Count);

            Console.WriteLine("Is viso patinu: {0}", TaskUtils.CountByGender(allDogs, Gender.Male));
            Console.WriteLine("Is viso pateliu: {0}", TaskUtils.CountByGender(allDogs, Gender.Female));
            Console.WriteLine();

            Dog oldest = TaskUtils.FindOlderDog(allDogs);
            Console.WriteLine("Seniausias suo");
            Console.WriteLine("Vardas: {0}, Veisle: {1}, Amzius: {2}", oldest.Name, oldest.Breed, oldest.CalculateAge());
            Console.WriteLine();

            List<string> Breeds = TaskUtils.FindBreeds(allDogs);
            Console.WriteLine("Sunu veisles:");
            InOutUtils.PrintBreeds(Breeds);
            Console.WriteLine();

            Console.WriteLine("Kokios veisles sunis atrinkti?");
            string selectedBreed = Console.ReadLine();
            List<Dog> FilteredByBreed = TaskUtils.FilterByBreed(allDogs, selectedBreed);
            InOutUtils.PrintDogs(FilteredByBreed);

            string fileName = selectedBreed + ".csv";
            InOutUtils.PrintDogsToCSVFile(fileName, FilteredByBreed);

            Console.ReadKey();
        }
    }
}
