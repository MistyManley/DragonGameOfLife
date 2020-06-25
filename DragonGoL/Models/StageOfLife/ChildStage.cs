using System;
using System.Collections.Generic;
using System.Text;

namespace DragonGoL.Models.StageOfLife
{
    public class ChildStage : IStageOfLife
    {
        public static int MaxAge => 300;

        public int DailyHappinessDecrease => 40;

        public int DailyHunger => 40;
    }
}
