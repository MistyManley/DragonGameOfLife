using System;
using Akka;
using Akka.Actor;

namespace DragonGoL
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Dragon Game Of Life.");
            var input = Console.ReadLine();
            using (var dragonSystem = ActorSystem.Create("DragonSystem"))
            {
                var commandControl = dragonSystem.ActorOf(Control.ControlActor.Props(), "Dragon Supervisor");
                while (string.Compare(input, "Exit", true) == 0)
                {
                    commandControl.Tell(input);


                }

            }
        }
    }
}
