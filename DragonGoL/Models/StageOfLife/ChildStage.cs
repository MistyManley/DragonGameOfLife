namespace DragonGoL.Models.StageOfLife
{
    /// <summary>
    /// Child <see cref="IStageOfLife"/>.
    /// </summary>
    public class ChildStage : IStageOfLife
    {
        public static int MaxAge => 300;

        public int DailyHappinessDecrease => 15;

        public int DailyHunger => 15;

        public string StageDescription => "Child";
    }
}
