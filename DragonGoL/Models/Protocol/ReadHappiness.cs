namespace DragonGoL.Models.Protocol
{
    /// <summary>
    /// Command to read the happiness of a dragon.
    /// </summary>
    public class ReadHappiness
    {
        public ReadHappiness(long requestId)
        {
            RequestId = requestId;
        }

        public long RequestId { get; }
    }
}
