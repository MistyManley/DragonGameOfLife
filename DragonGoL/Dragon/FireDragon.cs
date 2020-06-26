using Akka.Actor;
using Akka.Event;
using DragonGoL.Models.StageOfLife;
using DragonGoL.Models.Food;
using DragonGoL.Models.Protocol;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Diagnostics;

namespace DragonGoL.Dragon
{
    /// <summary>
    /// A Dragon who grows up to be a Fire Dragon. Likes charocal.
    /// </summary>
    public class FireDragon : UntypedActor
    {
        ILoggingAdapter Log = Context.GetLogger();

        private decimal age = 0;
        private int happinessLevel = 50;
        private const int MinHappinessLevel = 0;
        private const int MaxHappinessLevel = 100;
        private IStageOfLife stageOfLife = new BabyStage();
        private IActorRef stomach;
        private string Name { get; }
        private int weight;

        public FireDragon(string name, int startWeight)
        {
            Name = name;
            weight = startWeight;
        }
        protected override void PreStart()
        {
            base.PreStart();
            stomach = Context.ActorOf(Stomach.Props(), "FireDragonStomach");
        }

        protected override void OnReceive(object message)
        {
            Log.Debug("Dragon received: {message}");
            switch (message)
            {
                case Feed feed:
                    FoodReceived(feed.Food);
                    break;
                case Play play:
                    PlayReceived(play.HappinessValue);
                    break;
                case ReadHappiness happy:
                    Sender.Tell(new RespondHappiness(happy.RequestId, happinessLevel));
                    break;
                case ReadHunger hunger:
                    stomach.Forward(hunger);
                    break;
                case ReadStageOfLife stage:
                    Sender.Tell(new RespondStageOfLife(stage.RequestId, stageOfLife));
                    break;
                case Grow grow:
                    Grow(grow);
                    break;

                    //case RespondHunger respondHunger:
                    //    Sender.Forward(respondHunger);
                    //    break;
            }
        }

        private void Grow(Grow grow)
        {
            age += grow.DaysToGrow;
            UpdateStageOfLife();
            AdjustHappiness((int)( -1 * stageOfLife.DailyHappinessDecrease * grow.DaysToGrow));
            stomach.Tell(new ProcessFood((int)(stageOfLife.DailyHunger * grow.DaysToGrow)));
        }

        private void FoodReceived(IFood food)
        {
            if (food is Charcoal)
            {
                stomach.Forward(food);
                AdjustHappiness(food.HappinessValue);
                return;
            }
            if (happinessLevel < 20)
            {
                // Dont eat if unhappy
                return;
            }
            else
            {
                stomach.Forward(food);
                AdjustHappiness(food.HappinessValue);
            }
        }

        private void AdjustHappiness(int changeValue)
        {
            happinessLevel = Math.Min(MaxHappinessLevel, Math.Max(MinHappinessLevel, happinessLevel + changeValue));
        }

        private void PlayReceived(int happiness)
        {
            AdjustHappiness(happiness);
        }

        private void UpdateStageOfLife()
        {
            Log.Debug($"CurrentStage: {stageOfLife.GetType()} age: {age}");
            if (stageOfLife is AdultStage)
            {   // no need to change anything here.
                return;
            }
            if (stageOfLife is TeenStage && age > TeenStage.MaxAge)
            {
                stageOfLife = new AdultStage();
            }
            if (stageOfLife is ChildStage && age > ChildStage.MaxAge)
            {
                stageOfLife = new TeenStage();
            }
            if (stageOfLife is BabyStage && age > BabyStage.MaxAge)
            {
                stageOfLife = new ChildStage();
            }
            // else we are still a baby. 
        }

        public static Props Props(string name, int startWeight) => Akka.Actor.Props.Create(() => new FireDragon(name, startWeight));
    }
}
