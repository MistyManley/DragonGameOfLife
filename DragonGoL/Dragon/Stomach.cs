using Akka.Actor;
using Akka.Event;
using DragonGoL.Models.Food;
using DragonGoL.Models.Protocol;
using System;

namespace DragonGoL.Dragon
{
    /// <summary>
    /// A Dragons Stomach - used to control the hunger levels, receive and process food.
    /// </summary>
    public class Stomach : UntypedActor
    {
        ILoggingAdapter Log = Context.GetLogger();

        private const int MinLevel = 0;
        private const int MaxLevel = 100;
        private int hungerLevel = 50;
        protected override void OnReceive(object message)
        {
            Log.Debug("Dragon received: {message}");
            switch (message)
            {
                case IFood food:
                    hungerLevel = Math.Max(hungerLevel - food.HungerValue, MinLevel);
                    break;
                case ReadHunger hunger:
                    Sender.Tell(new RespondHunger(hunger.RequestId, hungerLevel));
                    break;
                case ProcessFood processFood:
                    hungerLevel = Math.Min(hungerLevel + processFood.QuantityProcessed, MaxLevel);
                    break;
            }
        }

        public static Props Props() => Akka.Actor.Props.Create<Stomach>();

    }
}
