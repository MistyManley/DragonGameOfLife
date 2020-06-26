using Akka.Actor;
using System;

namespace DragonGoL
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Dragon Game Of Life.");
            using (var dragonSystem = ActorSystem.Create("DragonSystem"))
            {
                var commandControl = dragonSystem.ActorOf(Control.ConsoleControl.Props(), "ConsoleControl");
                commandControl.Tell("start");
                while (!commandControl.IsNobody())
                {

                }
            }
        }

    }
}
