using System;
using Xunit;
using DragonGoL.Dragon;
using Akka.Actor;
using Akka.TestKit.Xunit2;
using DragonGoL.Models.Food;
using DragonGoL.Models.Protocol;

namespace DragonGoLTests
{
    public class StomachTests : TestKit
    {
        [Fact]
        public void New_Stomach_Read_Hunger()
        {
            var stomach = Sys.ActorOf(Props.Create(() => new Stomach()));
            stomach.Tell(new ReadHunger(1));
            var result = ExpectMsg<RespondHunger>().HungerValue == 50;
            Assert.True(result);
        }

        [Fact]
        public void Stomach_Cant_Get_More_Than_Full()
        {
            var stomach = Sys.ActorOf(Props.Create(() => new Stomach()));
            stomach.Tell(new TestFood(100,0));
            stomach.Tell(new ReadHunger(1));
            var result = ExpectMsg<RespondHunger>().HungerValue == 0;
            Assert.True(result);
        }

        [Fact]
        public void Stomach_Process_Food()
        {
            var stomach = Sys.ActorOf(Props.Create(() => new Stomach()));
            stomach.Tell(new ProcessFood(10));
            stomach.Tell(new ReadHunger(1));
            var result = ExpectMsg<RespondHunger>().HungerValue == 60;
            Assert.True(result);
        }

    }
}
