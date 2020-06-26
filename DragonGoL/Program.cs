using System;
using Akka;
using Akka.Actor;
using DragonGoL.Models.Commands;
using DragonGoL.Models.Protocol;

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
                while(true)
                {

                }
            }
        }

    }
}
