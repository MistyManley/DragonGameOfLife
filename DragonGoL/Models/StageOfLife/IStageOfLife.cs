namespace DragonGoL.Models.StageOfLife
{
    /// <summary>
    /// Stage Of Life. 
    /// </summary>
    public interface IStageOfLife
    {
       static int  MaxAge { get;}
       string StageDescription { get; }
       int DailyHappinessDecrease { get; }
       int DailyHunger { get; }
    }
}
