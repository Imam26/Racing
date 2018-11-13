using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Racing
{
    class FirstCar : Car
    {
        public delegate bool FinishEventHandler(int distance, FirstCar car);
        public event FinishEventHandler FinishEvent;

        public FirstCar(string mark, string model, int speed) : base(mark, model, speed) { }

        public override bool Drive(int second, Func<int, Car, bool> func)
        {
            Distance += Speed * second;

            FinishEvent = new FinishEventHandler(func);

            return FinishEvent(Distance, this);
        }

        public override void ChangeSpeed()
        {
            Thread.Sleep(20);
            Speed = new Random(DateTime.Now.Millisecond).Next(10, 20);
        }

        public override void Show()
        {
            Console.WriteLine("{0} {1}, speed:{2}, distance: {3}", Mark, Model, Speed, Distance);
        }
    }
}
