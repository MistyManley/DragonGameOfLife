using System;
using Xunit;
using DragonGoL.Dragon;
using Akka.Actor;
using Akka.TestKit.Xunit2;
using DragonGoL.Control;
using DragonGoL.Models.Commands;
using Akka.Dispatch.SysMsg;
using DragonGoL.Models.Protocol;
using DragonGoL.Models.StageOfLife;

namespace DragonGoLTests
{
    public class DragonControlTests : TestKit
    {
        [Fact]
        public void Check_For_No_Dragon()
        {
            var dragonControl = Sys.ActorOf(Props.Create(() => new DragonControl()));
            dragonControl.Tell(new ReadHappiness(1));
            var result = ReceiveOne();
            Assert.True(result is NoDragon);
        }
        [Fact]
        public void Create_New_Dragon()
        {
            var dragonControl = Sys.ActorOf(Props.Create(() => new DragonControl()));
            dragonControl.Tell(new CreateNewDragon("", "Dudley", 20));
            dragonControl.Tell(new ReadHappiness(1));
            var result = ReceiveOne();
            Assert.True(!(result is NoDragon));
        }

        [Fact]
        public void Read_Dragon_Happiness()
        {
            var dragonControl = Sys.ActorOf(Props.Create(() => new DragonControl()));
            dragonControl.Tell(new CreateNewDragon("", "Dudley", 20));
            dragonControl.Tell(new ReadHappiness(1));
            var result = ExpectMsg<RespondHappiness>().HappinessValue == 50;
            Assert.True(result);
        }

        [Fact]
        public void Read_Dragon_Hunger()
        {
            var dragonControl = Sys.ActorOf(Props.Create(() => new DragonControl()));
            dragonControl.Tell(new CreateNewDragon("", "Dudley", 20));
            dragonControl.Tell(new ReadHunger(1));
            var result = ExpectMsg<RespondHunger>().HungerValue == 50;
            Assert.True(result);
        }

        [Fact]
        public void Read_Dragon_StageOfLife()
        {
            var dragonControl = Sys.ActorOf(Props.Create(() => new DragonControl()));
            dragonControl.Tell(new CreateNewDragon("", "Dudley", 20));
            dragonControl.Tell(new ReadStageOfLife(1));
            var result = ExpectMsg<RespondStageOfLife>().StageOfLife is BabyStage;
            Assert.True(result);
        }

        [Fact]
        public void Check_Dragon_Ages_Over_Time()
        {
            var dragonControl = Sys.ActorOf(Props.Create(() => new DragonControl()));
            dragonControl.Tell(new CreateNewDragon("", "Dudley", 20));
            // System.Threading.Thread.Sleep(new TimeSpan(0, BabyStage.MaxAge+1, 0));
            dragonControl.Tell(new ReadStageOfLife(1));
            var result = ExpectMsg<RespondStageOfLife>().StageOfLife is ChildStage;
            Assert.True(result);
        }


    }
}
