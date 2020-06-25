using System;
using System.Collections.Generic;
using System.Text;

namespace DragonGoL.Models.StageOfLife
{
    public interface IStageOfLife
    {
       static int  MaxAge { get;}
       int DailyHappinessDecrease { get; }
       int DailyHunger { get; }
    }
}
