using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racing
{
    abstract class Car
    {
        public string Mark { get; set; }
        public string Model { get; set; }
        public int Speed { get; set; }
        public int Distance { get; set; }

        public Car(string mark, string model, int speed)
        {
            Mark = mark;
            Model = model;
            Speed = speed;
        }

        public abstract bool Drive(int second, Func<int, Car, bool> func);

        public abstract void ChangeSpeed();

        public abstract void Show();
        
    }
}
