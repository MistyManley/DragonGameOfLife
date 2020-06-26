using Akka.Actor;
using Akka.Event;
using DragonGoL.Models.Commands;
using System;

namespace DragonGoL.Control
{
    /// <summary>
    /// An Actor used to read input from the console
    /// </summary>
    public class ConsoleRead : UntypedActor
    {
        ILoggingAdapter Log = Context.GetLogger();

        protected override void OnReceive(object message)
        {
            switch (message)
            {
                case "read":
                    var read = Console.ReadLine();
                    Sender.Tell(new TextEntered(read));
                    break;
            }
        }

        public static Props Props() => Akka.Actor.Props.Create<ConsoleRead>();
    }
}
