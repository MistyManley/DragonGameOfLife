using Akka.Actor;
using Akka.Event;
using DragonGoL.Dragon;
using DragonGoL.Models.Commands;
using DragonGoL.Models.Protocol;
using System;

namespace DragonGoL.Control
{
    /// <summary>
    /// The top level AKKA Supervisor in charge of the Console management
    /// </summary>
    public class ConsoleControl : UntypedActor
    {
        ILoggingAdapter Log = Context.GetLogger();
        IActorRef dragonControl;
        IActorRef consoleRead;
        string currentDragonName;

        protected override void PreStart()
        {
            base.PreStart();
            dragonControl = Context.ActorOf(DragonControl.Props(), "DragonControl");
            consoleRead = Context.ActorOf(ConsoleRead.Props(), "ConsoleRead");
        }

        protected override void OnReceive(object message)
        {
            //TODO: handle death watch of dragon.
            switch (message)
            {
                case "start":
                    ProgramStart();
                    break;
                case TextEntered text:
                    CommandInput(text.Text);
                    break;
                case RespondHappiness respondHappiness:
                    Console.WriteLine($"{currentDragonName} Happiness Level = {respondHappiness.HappinessValue}");
                    break;
                case RespondHunger respondHunger:
                    Console.WriteLine($"{currentDragonName} Hunger Level = {respondHunger.HungerValue}");
                    break;
                case RespondStageOfLife respondStageOfLife:
                    Console.WriteLine($"{currentDragonName} is a {respondStageOfLife.StageOfLife.StageDescription}");
                    break;
                case NoDragon noDragon:
                    Console.WriteLine($"Error: No Dragon to update. Create a new dragon first.");
                    break;
                case DragonCreated dragon:
                    Console.WriteLine($"New Dragon Created: {dragon}");
                    break;
            }


        }

        private void ProgramStart()
        {
            Console.WriteLine("To create a new dragon use command: new (n)");
            consoleRead.Tell("read");
        }

        private void NextCommand()
        {
            Console.WriteLine("Commands available are: new (n), feed (f), play (p), status (s) and exit");
            consoleRead.Tell("read");
        }

        private void CommandInput(string text)
        {
            switch (text)
            {
                case "new":
                case "n":
                    CreateNewDragonCommand();
                    break;
                case "feed":
                case "f":
                    FeedDragonCommand();
                    break;
                case "play":
                case "p":
                    PlayDragonCommand();
                    break;
                case "status":
                case "s":
                    GetDragonStatus();
                    break;
            }
            NextCommand();
        }

        private void CreateNewDragonCommand()
        {
            Console.WriteLine("Please specify the dragons name");
            currentDragonName = Console.ReadLine();
            Console.WriteLine("Please specify the dragons start weight");
            var weight = Console.ReadLine();
            int.TryParse(weight, out int intWeight);
            var dragon = Context.ActorOf(FireDragon.Props(currentDragonName, intWeight), currentDragonName);
            dragonControl.Tell(new CreateNewDragon(dragon));
            GetDragonStatus();
        }

        private void FeedDragonCommand()
        {
            Console.WriteLine($"Please specify the type of food: {FeedDragon.KnownFoods}");
            var foodType = Console.ReadLine().Trim();
            while (!FeedDragon.KnownFoods.Contains(foodType))
            {
                Console.WriteLine("Invalid food type chosen.");
                foodType = Console.ReadLine().Trim();
            }
            dragonControl.Tell(new FeedDragon(foodType));
            GetDragonStatus();
        }
        private void PlayDragonCommand()
        {

            Console.WriteLine($"Please specify the type of play: {PlayWithDragon.KnownPlayTypes}");
            var playType = Console.ReadLine().Trim();
            while (!PlayWithDragon.KnownPlayTypes.Contains(playType))
            {
                Console.WriteLine("Invalid play type chosen.");
                playType = Console.ReadLine().Trim();
            }
            dragonControl.Tell(new PlayWithDragon(playType));
            GetDragonStatus();
        }

        private void GetDragonStatus()
        {
            dragonControl.Tell(new ReadHappiness(1));
            dragonControl.Tell(new ReadHunger(2));
        }

        public static Props Props() => Akka.Actor.Props.Create<ConsoleControl>();
    }
}
