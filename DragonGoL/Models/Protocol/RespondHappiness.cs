namespace DragonGoL.Models.Protocol
{
    /// <summary>
    /// Command to surface a happiness value.
    /// </summary>
    public class RespondHappiness
    {
        public RespondHappiness(long requestId, int happinessValue)
        {
            RequestId = requestId;
            HappinessValue = happinessValue;
        }

        public long RequestId { get; }
        public int HappinessValue { get; }
    }
}
