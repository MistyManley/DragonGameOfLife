using DragonGoL.Models.StageOfLife;
using System;
using System.Collections.Generic;
using System.Text;

namespace DragonGoL.Models.Protocol
{
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
