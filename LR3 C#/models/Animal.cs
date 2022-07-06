using System;

namespace laba3.models
{
    public abstract class Animal
    {
        public string Name {get; set;}
        public int Weight { get; set; }
        public int Age { get; set; }

        public void GetAge()
        {
            Console.WriteLine($"{Name} aka {Age}");
        }

        public void SayWeight()
        {
            Console.WriteLine($"{Name} is about {Weight}");
        }

        public abstract void Move();
    }
}