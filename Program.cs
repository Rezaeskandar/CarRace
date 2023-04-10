using Newtonsoft.Json;
using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace CarRace
{
    internal partial class Program
    {
        static async Task Main(string[] args)
        {
            start:
            List<CarModel> Cars = new List<CarModel>();
            CarModel car1 = new CarModel("Car 1");
            CarModel car2 = new CarModel("Car 2");
            CarModel car3 = new CarModel("Car 3");
            CarModel car4 = new CarModel("Car 4");
            CarModel car5 = new CarModel("Car 5"); 
 

            Task task1 = car1.StartRace();
            Task task2 = car2.StartRace();
            Task task3 = car3.StartRace();
            Task task4 = car4.StartRace();
            Task task5 = car5.StartRace();

            Cars.Add(car1);
            Cars.Add(car2);
            Cars.Add(car3);
            Cars.Add(car4);
            Cars.Add(car5);

            //Väntar in tills alla bilar kört klart
            await Task.WhenAll(task1, task2, task3, task4, task5);

            Console.WriteLine("\nBill tävlingen är slut!");

            //Hitta vinnaren
            int maxDistance = -1;
            CarModel? winner = null;
            foreach (CarModel car in Cars)
            {
                if (car.distance > maxDistance)
                {
                    maxDistance = (int)car.distance;
                    winner = car;
                }
            }
            Console.ForegroundColor= ConsoleColor.Green;
            Console.WriteLine($"\n{winner.name} har vunnit tävlingen!");
            Console.ResetColor();


            //TODO Create a  status for every car 
            Console.ForegroundColor= ConsoleColor.DarkYellow;
            Console.WriteLine("\n skriv ordet 'status' för at bilarnas status Eller skriv 'start' för att börja tävlingen om!'");
            Console.ResetColor();
            var input = Console.ReadLine();
            if (input.ToLower() == "status")
            {
                // Skriv ut status för alla bilar
                foreach (var car in Cars)
                {
                    Console.WriteLine($"{car.name} har kört {car.distance:N0} m/s  meter och kör i {car.speed} km/h.\n");
                }
            }
            else if (input.ToLower() == "back")
            {
                goto start;
            }

        }
    
    
    }
 }
