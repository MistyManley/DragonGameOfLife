using System;
using System.Collections.Generic;
using System.Text;

namespace DragonGoL.Models.Protocol
{
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
