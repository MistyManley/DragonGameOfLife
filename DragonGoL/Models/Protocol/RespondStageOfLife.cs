using DragonGoL.Models.StageOfLife;

namespace DragonGoL.Models.Protocol
{
    /// <summary>
    /// Command to surface a <see cref="IStageOfLife"/> value.
    /// </summary>
    public class RespondStageOfLife
    {
        public RespondStageOfLife(long requestId, IStageOfLife stageOfLifeValue)
        {
            RequestId = requestId;
            StageOfLife = stageOfLifeValue;
        }

        public long RequestId { get; }
        public IStageOfLife StageOfLife { get; }
    }
}
