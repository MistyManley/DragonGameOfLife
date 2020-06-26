namespace DragonGoL.Models.Protocol
{
    /// <summary>
    /// Command to read the Stage Of Life of a dragon.
    /// </summary>
    public class ReadStageOfLife
    {
        public ReadStageOfLife(long requestId)
        {
            RequestId = requestId;
        }

        public long RequestId { get; }
    }
}
