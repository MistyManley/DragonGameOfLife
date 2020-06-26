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
    public class DragonTests : TestKit
    {
       
        [Fact]
        public void New_Dragon_Read_StageOfLife()
        {
            var dragon = Sys.ActorOf(Props.Create(() => new FireDragon("TestDragon",3)));
            dragon.Tell(new ReadStageOfLife(1));
            var result = ExpectMsg<RespondStageOfLife>().StageOfLife is BabyStage;
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
