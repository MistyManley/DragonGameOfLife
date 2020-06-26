namespace DragonGoL.Models.Protocol
{
    /// <summary>
    /// Command to surface a hunger value.
    /// </summary>
    public class RespondHunger
    {
        public RespondHunger(long requestId, int hungerValue)
        {
            RequestId = requestId;
            HungerValue = hungerValue;
        }

        public long RequestId { get; }
        public int HungerValue { get; }
    }
}
