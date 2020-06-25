using System;
using System.Collections.Generic;
using System.Text;

namespace DragonGoL.Models.Protocol
{
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
