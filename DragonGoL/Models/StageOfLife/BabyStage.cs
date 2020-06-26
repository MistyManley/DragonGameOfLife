namespace DragonGoL.Models.StageOfLife
{
    /// <summary>
    /// Intial baby <see cref="IStageOfLife"/>.
    /// </summary>
    public class BabyStage : IStageOfLife
    {
        public static int MaxAge => 50;

        public int DailyHappinessDecrease => 10;

        public int DailyHunger => 10;

        public string StageDescription => "Baby";
    }
}
