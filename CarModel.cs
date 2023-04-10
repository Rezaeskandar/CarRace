using System.Xml.Linq;

namespace CarRace
{
    internal partial class Program
    {
        public class CarModel
        {
            public string name { get; set; }
            public decimal distance { get; set; }
            public int speed { get; set; } = 0;
            public int targetDistance { get; set; } = 250;
            //public decimal tick { get; set; } = 30M;
            public Random random { get; set; }
            public CarModel(string name)

            {
                this.name = name;
                distance = 0;
                speed = 120;
                random = new Random();
            }

            public async Task StartRace()
            {
                Console.WriteLine($"{name} startar!");

                while (distance < targetDistance)
                {
                    // Vänta 30 sekunder
                    for (int i = 0; i < 10; i++)
                    {

                        if (i % 4 == 0)
                        {
                            Console.Write("\r");
                        }
                        else if (i % 4 == 1)
                        {
                            Console.Write(".");
                        }
                        else if (i % 4 == 2)
                        {
                            Console.Write("..");
                        }
                        else
                        {
                            Console.Write("...");
                        }

                         await Task.Delay(300);
                    }  

                    // slumpa händelse
                    int eventChance = random.Next(50);
                    if (eventChance == 0)
                    {
                        await outOfGas();
                    }
                    else if (eventChance <= 2)
                    {
                        await flatTire();
                    }
                    else if (eventChance <= 7)
                    {
                        await dirtyWindshield();
                    }
                    else if (eventChance <= 17)
                    {
                        await engineProblem();
                    }
                    else
                    {
                      
                    }

                    // Uppdatera avstånd

                    //distance += speed;

                    //// Skriv ut status
                    //Console.WriteLine($"{name} har nu kört {distance} i {tick} meter och kör i {speed} km/h. ");
                    // calculate distance based on current speed and elapsed time
                    decimal distanceMoved = (speed / 3.6M); // 3.6 is the conversion factor from km/h to m/s
                    distance += distanceMoved;
                    Console.WriteLine($"{name} har nu kört {distance:N0} m/s  meter och kör i {speed} km/h. ");
                    //Console.Write("\r{0,-15} [{1}] {2:N2} m/s, {3:N2} km/h, {4:N2} m",
                    //    name, new string('.', (int)(distance / targetDistance * 10)), speed / 3.6, speed, distance);
                }

            }
            private async Task outOfGas()
            {
                Console.WriteLine($"\n{name} har slut på bensin och behöver tanka!");
                await Task.Delay(30000);
                Console.WriteLine($"{name} har nu tankat och fortsätter köra.");
            }

            private async Task flatTire()
            {
                Console.WriteLine($"\n{name} har fått punktering och behöver byta däck!");
                await Task.Delay(20000);
                Console.WriteLine($"{name} har nu bytt däck och fortsätter köra.");
            }
            private async Task dirtyWindshield()
            {
                Console.WriteLine($"\n{name} har fått en fågel på vindrutan och behöver tvätta den!");
                await Task.Delay(10000);
                Console.WriteLine($"{name} har nu tvättat vind");
            }
            private async Task engineProblem()
            {
                Console.WriteLine($"\n{name} har fått motorproblem och hastigheten sänks med 1 km/h.");
                speed -= 1;
                await Task.Delay(30000);
                Console.WriteLine($"{name} har nu åtgärdat problemet och fortsätter köra i {speed} km/h.\n");
            }

           
        }
    
    
    }
 }
