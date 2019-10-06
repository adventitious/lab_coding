using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labsheet3
{
    class Car
    {
        private string make;
        public string Make
        {
            get
            {
                return this.make;
            }
            set
            {
                this.make = value;
            }
        }



        private string model;
        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                this.model = value;
            }
        }



        private int currentSpeed;
        public int CurrentSpeed
        {
            get
            {
                return this.currentSpeed;
            }
            set
            {
                this.currentSpeed = value;
            }
        }



        private double engineSize;
        public double EngineSize
        {
            get
            {
                return this.engineSize;
            }
            set
            {
                this.engineSize = value;
            }
        }

        public void DisplayCarInfo()
        {
            Console.WriteLine("make and model: {0} {1}", Make, Model);
            Console.WriteLine("current speed: {0}", CurrentSpeed);
            Console.WriteLine("engine size: {0}\n", EngineSize);
        }


        public string ToString()
        {
            string output = String.Format("make and model: {0} {1}\n", Make, Model);
            output += String.Format("current speed: {0}\n", CurrentSpeed);
            output += String.Format("engine size: {0}\n\n", EngineSize);
            return output;
        }

        public void Accelerate()
        {
            CurrentSpeed += 10;
        }
    }
}
