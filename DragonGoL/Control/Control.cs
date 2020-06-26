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
    class ControlActor : UntypedActor
    {
        ILoggingAdapter Log = Context.GetLogger();
        IActorRef dragon;
        DateTime lastUpdate;
        protected override void PreStart()
        {
            base.PreStart();
            //setup sub actors.

        }

        protected override void OnReceive(object message)
        {
            Log.Debug($"Control Actor received message: {message}");
            switch (message)
            {
                //TODO: Improve how we control these commands.
                case CreateNewDragon createNew:
                    dragon = Context.ActorOf(FireDragon.Props(createNew.Name, createNew.Weight), createNew.Name);
                    lastUpdate = DateTime.Now;
                    break;
                case FeedDragon feedDragon:
                    if (dragon.IsNobody()) return;
                    dragon.Tell(new Feed(feedDragon.Food));
                    break;
                case PlayWithDragon play:
                    dragon.Tell(new Play(play.HappinessValue));
                    break;
                case StatusUpdate status:
                    Update();
                    break;
            }
            //after all commands always Update. 
            Update();
        }


        private void Update()
        {
            if (dragon.IsNobody()) return;
            //TODO: age dragon
            //TODO: process food
            //TODO: check dragon alive.
            decimal timeSinceLastCheck = (decimal)((DateTime.Now - lastUpdate).TotalMinutes);
            dragon.Tell(new Grow(timeSinceLastCheck));
        }
        public static Props Props() => Akka.Actor.Props.Create<ControlActor>();
    }
}
