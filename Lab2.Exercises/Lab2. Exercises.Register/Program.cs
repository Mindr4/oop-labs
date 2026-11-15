using Lab2.Exercises.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.ExercisesRegister
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DogsRegister register = InOutUtils.ReadDogs("Dogs.txt");
            Console.WriteLine("Iš viso šunų: {0}", register.DogsCount());
            InOutUtils.PrintDogs(register);
            Console.WriteLine("Patinų : {0}", register.CountByGender(Gender.Male));
            Console.WriteLine("Patelių : {0}", register.CountByGender(Gender.Female));
            List<Vaccination> VaccinationsData = InOutUtils.ReadVaccinations("Vaccinations.txt");
            register.UpdateVaccinationInfo(VaccinationsData);
        }
    }
}
