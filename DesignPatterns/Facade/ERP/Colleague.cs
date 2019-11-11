using System;

namespace Facade
{
    class Colleague
    {
        public Colleague(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public void AddToDo(string toDo)
        {
            Console.WriteLine($"{Name}: {toDo}");
        }
    }
}