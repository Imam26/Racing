using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racing
{
    class Game
    {
        private List<Car> cars;

        public int Distance { get; set; }

        public delegate bool ManageCar(int param, Func<int, Car, bool> func);
        public delegate void OperationWithParamertsCar();

        ManageCar manageCar;
        OperationWithParamertsCar operation;

        public Game(List<Car> cars, int distance)
        {
            this.cars = new List<Car>(cars);
            Distance = distance;
        }

        public bool IsRacing()
        {
            cars.Sort(delegate(Car fCar, Car sCar) { return sCar.Distance.CompareTo(fCar.Distance); } );
            
            foreach(Car car in cars)
            {
                operation += car.Show;
                operation += car.ChangeSpeed;
            }

            operation();

            foreach(Car car in cars)
            {
                manageCar = new ManageCar(car.Drive);
                operation -= car.Show;
                operation -= car.ChangeSpeed;
                
                if (manageCar(1, IsFinish))
                {
                    Console.WriteLine("---------Finish!!!----------");
                    operation = new OperationWithParamertsCar(car.Show);
                    operation();
                    return true;
                }
            }

            return false;
        }

        public bool IsFinish(int distance, Car car)
        {
            if (car.Distance >= Distance)
                return true;
            return false;
        }

    }
}
