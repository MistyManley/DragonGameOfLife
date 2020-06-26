namespace DragonGoL.Models.StageOfLife
{
    /// <summary>
    /// Eternally living adult <see cref="IStageOfLife"/>.
    /// </summary>
    public class AdultStage : IStageOfLife
    {
        public int MaxAge => int.MaxValue;

        public int DailyHappinessDecrease => 30;

        public int DailyHunger => 30;

        public string StageDescription => "Adult";
    }
}
