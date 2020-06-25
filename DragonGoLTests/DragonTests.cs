using System;
using Xunit;
using DragonGoL.Dragon;
using Akka.Actor;
using Akka.TestKit.Xunit2;
using DragonGoL.Models.Food;
using DragonGoL.Models.Protocol;
using DragonGoL.Models.StageOfLife;

namespace DragonGoLTests
{
    public class DragonTests : TestKit
    {
        [Fact]
        public void New_Dragon_Read_Hunger()
        {
            var dragon = Sys.ActorOf(Props.Create(() => new FireDragon("TestDragon",3)));
            dragon.Tell(new ReadHunger(1));
            var result = ExpectMsg<RespondHunger>().HungerValue == 50;
            Assert.True(result);
        }

        [Fact]
        public void New_Dragon_Read_Happiness()
        {
            var dragon = Sys.ActorOf(Props.Create(() => new FireDragon("TestDragon",3)));
            dragon.Tell(new ReadHappiness(1));
            var result = ExpectMsg<RespondHappiness>().HappinessValue == 50;
            Assert.True(result);
        }

        [Fact]
        public void New_Dragon_Read_StageOfLife()
        {
            var dragon = Sys.ActorOf(Props.Create(() => new FireDragon("TestDragon",3)));
            dragon.Tell(new ReadStageOfLife(1));
            var result = ExpectMsg<RespondStageOfLife>().StageOfLife is BabyStage;
            Assert.True(result);
        }

        [Fact]
        public void Dragon_Happiness_Goes_Down_After_Eating_Vegetables()
        {
            var dragon = Sys.ActorOf(Props.Create(() => new FireDragon("TestDragon",3)));
            dragon.Tell(((IFood)new Greenery()));
            dragon.Tell(new ReadHappiness(1));
            var result = ExpectMsg<RespondHappiness>().HappinessValue < 50;
            Assert.True(result);
        }

        [Fact]
        public void Dragon_Happiness_Goes_Up_After_Eating_Charcoal()
        {
            var dragon = Sys.ActorOf(Props.Create(() => new FireDragon("TestDragon",3)));
            dragon.Tell(((IFood)new Charcoal()));
            dragon.Tell(new ReadHappiness(1));
            var result = ExpectMsg<RespondHappiness>().HappinessValue > 50;
            Assert.True(result);
        }

        [Fact]
        public void Dragon_Happiness_Goes_Down_After_Growing()
        {
            var dragon = Sys.ActorOf(Props.Create(() => new FireDragon("TestDragon",3)));
            dragon.Tell(new Grow(1));
            dragon.Tell(new ReadHappiness(1));
            var result = ExpectMsg<RespondHappiness>().HappinessValue < 50;
            Assert.True(result);
        }
        
        [Fact]
        public void Dragon_Test_Age_Transitions()
        {
            var dragon = Sys.ActorOf(Props.Create(() => new FireDragon("TestDragon",3)));
            dragon.Tell(new ReadStageOfLife(1));
            var result = ExpectMsg<RespondStageOfLife>().StageOfLife is BabyStage;
            Assert.True(result);

            dragon.Tell(new Grow(BabyStage.MaxAge+1));
            dragon.Tell(new ReadStageOfLife(1));
            result = ExpectMsg<RespondStageOfLife>().StageOfLife is ChildStage;
            Assert.True(result);

            dragon.Tell(new Grow(ChildStage.MaxAge-BabyStage.MaxAge+1));
            dragon.Tell(new ReadStageOfLife(1));
            result = ExpectMsg<RespondStageOfLife>().StageOfLife is TeenStage;
            Assert.True(result);

            dragon.Tell(new Grow(TeenStage.MaxAge-ChildStage.MaxAge+1));
            dragon.Tell(new ReadStageOfLife(1));
            result = ExpectMsg<RespondStageOfLife>().StageOfLife is AdultStage;
            Assert.True(result);

        }
    }
}
