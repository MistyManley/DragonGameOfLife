namespace DragonGoL.Models.Protocol
{
    /// <summary>
    /// Command to play with the dragon and increase its happiness value.
    /// </summary>
    public class Play
    {
        public Play(int happinessValue)
        {
            HappinessValue = happinessValue;
        }
        public int HappinessValue { get; }
    }
}
