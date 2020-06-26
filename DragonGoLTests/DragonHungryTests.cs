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
    public class DragonHungryTests : TestKit
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
        public void Dragon_Hunger_Goes_Down_After_Eating_Food()
        {
            var dragon = Sys.ActorOf(Props.Create(() => new FireDragon("TestDragon",3)));
            dragon.Tell(new Feed((IFood)new Steak()));
            dragon.Tell(new ReadHunger(1));
            var result = ExpectMsg<RespondHunger>().HungerValue < 50;
            Assert.True(result);
        }

        [Fact]
        public void Dragon_Hunger_Goes_Up_After_Growing()
        {
            var dragon = Sys.ActorOf(Props.Create(() => new FireDragon("TestDragon",3)));
            dragon.Tell(new Grow(1));
            dragon.Tell(new ReadHunger(1));
            var result = ExpectMsg<RespondHunger>().HungerValue > 50;
            Assert.True(result);
        }
        
    }
}
