using System;
using System.Collections.Generic;
using System.Text;

namespace DragonGoL.Models.StageOfLife
{
    public class BabyStage : IStageOfLife
    {
        public static int MaxAge => 5;

        public int DailyHappinessDecrease => 10;

        public int DailyHunger => 10;

        public string StageDescription => "Baby";
    }
}
