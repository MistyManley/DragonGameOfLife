namespace DragonGoL.Models.StageOfLife
{
    /// <summary>
    /// Stroppy Teenager <see cref="IStageOfLife"/>.
    /// </summary>
    public class TeenStage : IStageOfLife
    {
        public static int MaxAge => 600;

        public int DailyHappinessDecrease => 20;

        public int DailyHunger => 20;

        public string StageDescription => "Stroppy Teen";
    }
}
