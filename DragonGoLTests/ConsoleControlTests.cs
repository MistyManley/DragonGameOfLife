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
    public class ConoleControlTests : TestKit
    {
        [Fact]
        public void Display_Dragon_Happiness()
        {
            var consoleControl = Sys.ActorOf(Props.Create(() => new ConsoleControl()));
            consoleControl.Tell(new RespondHappiness(1,50));
           // var result = ExpectMsg<RespondHappiness>().HappinessValue == 50;
           // Assert.True(result);
        }

        [Fact]
        public void Display_Dragon_Hunger()
        {
            var consoleControl = Sys.ActorOf(Props.Create(() => new ConsoleControl()));
            consoleControl.Tell(new RespondHunger(1, 50));
            //Assert.True(result);
        }

        [Fact]
        public void Display_Dragon_StageOfLife()
        {           
            var consoleControl = Sys.ActorOf(Props.Create(() => new ConsoleControl()));
            consoleControl.Tell(new RespondStageOfLife(1, new TeenStage()));
        }

        [Fact]
        public void Display_No_Dragon()
        {           
            var consoleControl = Sys.ActorOf(Props.Create(() => new ConsoleControl()));
            consoleControl.Tell(new NoDragon());
        }

    }
}
