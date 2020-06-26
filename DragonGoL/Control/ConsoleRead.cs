using Akka;
using Akka.Actor;
using Akka.Dispatch.SysMsg;
using Akka.Event;
using DragonGoL.Dragon;
using DragonGoL.Models.Commands;
using DragonGoL.Models.Food;
using DragonGoL.Models.Protocol;
using System;
using System.Collections.Generic;
using System.Net.Cache;
using System.Text;

namespace DragonGoL.Control
{
    /// <summary>
    /// The top level AKKA Supervisor.
    /// </summary>
    public class ConsoleRead : UntypedActor
    {
        ILoggingAdapter Log = Context.GetLogger();
        IActorRef dragonControl;
        string currentDragonName;

        protected override void PreStart()
        {
            base.PreStart();
            dragonControl = Context.ActorOf(DragonControl.Props(), "DragonControl");
        }

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
