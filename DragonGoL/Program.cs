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
            Console.WriteLine("Commands available are: new (n), feed (f), play (p), status (s) and exit");
            var input = Console.ReadLine().ToLower();
            using (var dragonSystem = ActorSystem.Create("DragonSystem"))
            {
                var commandControl = dragonSystem.ActorOf(Control.ControlActor.Props(), "DragonSupervisor");
                while (string.Compare(input, "Exit", true) != 0)
                {
                    switch (input)
                    {
                        case "new": 
                        case "n":
                            commandControl.Tell(CreateNewDragonCommand());
                            break;
                        case "feed":
                        case "f":
                            commandControl.Tell(FeedDragonCommand());
                            break;
                        case "play":
                        case "p":
                            commandControl.Tell(PlayDragonCommand());
                            break;
                        case "status":
                        case "s":
                            GetDragonStatus();
                            break;
                    }

                    Console.WriteLine("Commands available are: new (n), feed (f), play (p), status (s) and exit");
                    input = Console.ReadLine().ToLower();

                }

            }
        }

        private static CreateNewDragon CreateNewDragonCommand()
        {
            Console.WriteLine("Please specify the dragons name");
            var name = Console.ReadLine();
            Console.WriteLine("Please specify the dragons start weight");
            var weight = Console.ReadLine();
            int.TryParse(weight, out int intWeight);
            return new CreateNewDragon("FireDragon", name, intWeight);
        }

        private static FeedDragon FeedDragonCommand()
        {
            Console.WriteLine($"Please specify the type of food: {FeedDragon.KnownFoods}");
            var foodType = Console.ReadLine().Trim();
            while(!FeedDragon.KnownFoods.Contains(foodType))
            {
                Console.WriteLine("Invalid food type chosen.");
                foodType = Console.ReadLine().Trim() ;
            }
            return new FeedDragon(foodType);
        }
        private static PlayWithDragon PlayDragonCommand()
        {
            
            Console.WriteLine($"Please specify the type of play: {PlayWithDragon.KnownPlayTypes}");
            var playType = Console.ReadLine().Trim();
            while(!PlayWithDragon.KnownPlayTypes.Contains(playType))
            {
                Console.WriteLine("Invalid play type chosen.");
                playType = Console.ReadLine().Trim() ;
            }
            return new PlayWithDragon(playType);
        }

        private static void GetDragonStatus()
        {
            // ???
        }
    }
}
