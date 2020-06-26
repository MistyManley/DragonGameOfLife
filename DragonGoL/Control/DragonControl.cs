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
    public class DragonControl : UntypedActor
    {
        ILoggingAdapter Log = Context.GetLogger();
        IActorRef dragon;
        DateTime lastUpdate;

        protected override void OnReceive(object message)
        {
            Log.Debug($"Control Actor received message: {message}");
            //before all commands always update to set values to current. 
            Update();
            switch (message)
            {
                //TODO: Improve how we control these commands.
                case CreateNewDragon createNew:
                    dragon = Context.ActorOf(FireDragon.Props(createNew.Name, createNew.Weight), createNew.Name);
                    lastUpdate = DateTime.Now;
                    break;
                case FeedDragon feedDragon:
                    if (!CheckDragonExists()) return; 
                    dragon.Tell(new Feed(feedDragon.Food));
                    break;
                case PlayWithDragon play:
                    if (!CheckDragonExists()) return; 
                    dragon.Tell(new Play(play.HappinessValue));
                    break;
                case ReadHappiness readHappiness:
                    if (!CheckDragonExists()) return; 
                    dragon.Forward(readHappiness);
                    break;
                case ReadHunger readHunger:
                    if (!CheckDragonExists()) return; 
                    dragon.Forward(readHunger);
                    break;
                case ReadStageOfLife stage:
                    if (!CheckDragonExists()) return; 
                    dragon.Forward(stage);
                    break;
            }
        }

        private bool CheckDragonExists()
        {
            if (dragon.IsNobody())
                Sender.Tell(new NoDragon());
            return !dragon.IsNobody() ;
        }

        private void Update()
        {
            if (dragon.IsNobody()) return;
            //TODO: age dragon
            //TODO: check dragon alive.
            decimal timeSinceLastCheck = (decimal)((DateTime.Now - lastUpdate).TotalMinutes);
            dragon.Tell(new Grow(timeSinceLastCheck));
        }
        public static Props Props() => Akka.Actor.Props.Create<DragonControl>();
    }
}
