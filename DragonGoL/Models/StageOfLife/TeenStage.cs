using System;
using System.Collections.Generic;
using System.Text;

namespace DragonGoL.Models.StageOfLife
{
    public class TeenStage : IStageOfLife
    {
        public static int MaxAge => 600;

        public int DailyHappinessDecrease => 20;

        public int DailyHunger => 20;

        public string StageDescription => "Stroppy Teen";
    }
}
