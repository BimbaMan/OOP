using System;

namespace laba3.models
{
    public class Dog : Animal
    {
        public override void Move()
        {
            Console.WriteLine("I am moving on my 4 paws");
        }
    }
}