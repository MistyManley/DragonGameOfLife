using System;
using Xunit;
using DragonGoL.Dragon;
using Akka.Actor;
using Akka.TestKit.Xunit2;
using DragonGoL.Models.Food;
using DragonGoL.Models.Protocol;
using DragonGoL.Models.StageOfLife;
using DragonGoL.Models.Commands;

namespace DragonGoLTests
{
    public class DragonHappyTests : TestKit
    {
        [Fact]
        public void New_Dragon_Read_Happiness()
        {
            var dragon = Sys.ActorOf(Props.Create(() => new FireDragon("TestDragon",3)));
            dragon.Tell(new ReadHappiness(1));
            var result = ExpectMsg<RespondHappiness>().HappinessValue == 50;
            Assert.True(result);
        }

        [Fact]
        public void Dragon_Happiness_Goes_Down_After_Eating_Vegetables()
        {
            var dragon = Sys.ActorOf(Props.Create(() => new FireDragon("TestDragon",3)));
            dragon.Tell(new Feed((IFood)new Greenery()));
            dragon.Tell(new ReadHappiness(1));
            var result = ExpectMsg<RespondHappiness>().HappinessValue < 50;
            Assert.True(result);
        }

        [Fact]
        public void Dragon_Happiness_Goes_Up_After_Eating_Charcoal()
        {
            var dragon = Sys.ActorOf(Props.Create(() => new FireDragon("TestDragon",3)));
            dragon.Tell(new Feed((IFood)new Charcoal()));
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
        public void Dragon_Happiness_Goes_Up_After_Playing()
        {
            var dragon = Sys.ActorOf(Props.Create(() => new FireDragon("TestDragon", 3)));
            dragon.Tell(new Play(10));
            dragon.Tell(new ReadHappiness(1));
            var result = ExpectMsg<RespondHappiness>().HappinessValue == 60;
            Assert.True(result);
        }

    }
}
