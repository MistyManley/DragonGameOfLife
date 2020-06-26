namespace DragonGoL.Models.Protocol
{
    /// <summary>
    /// Command to read the hunger level of a dragon.
    /// </summary>
    public class ReadHunger
    {
        public ReadHunger(long requestId)
        {
            RequestId = requestId;
        }

        public long RequestId { get; }
    }
}
