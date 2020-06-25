using System;
using System.Collections.Generic;
using System.Text;

namespace DragonGoL.Models.StageOfLife
{
    public class BabyStage : IStageOfLife
    {
        public static int MaxAge => 100;

        public int DailyHappinessDecrease => 20;

        public int DailyHunger => 20;
    }
}
