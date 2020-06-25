using System;
using System.Collections.Generic;
using System.Text;

namespace DragonGoL.Models.StageOfLife
{
    public class AdultStage : IStageOfLife
    {
        public int MaxAge => int.MaxValue;

        public int DailyHappinessDecrease => 60;

        public int DailyHunger => 60;
    }
}
