namespace DragonGoL.Models.Protocol
{
    /// <summary>
    /// Command to grow the dragon by a given number of days.
    /// </summary>
    public class Grow
    {
        public Grow(decimal daysPassed)
        {
            DaysToGrow = daysPassed;
        }

        public decimal DaysToGrow { get; }
    }
}
