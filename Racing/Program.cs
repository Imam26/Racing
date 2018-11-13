using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Racing
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>
            {
                new FirstCar("BMX","M5",0),
                new SecondCar("Audi", "R7", 0),
                new ThirdCar("Subaru", "Impreza", 0)
            };

            Game newGame = new Game(cars, 100);

            int round = 1;

            Console.WriteLine("-------Prepare To Start!!!!-------");

            while (!newGame.IsRacing())
            {
                Console.WriteLine("         {0} round", round++);
            }
        }
    }
}
