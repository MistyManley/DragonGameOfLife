using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace DragonGoL.Models.Protocol
{
    public class ReadHappiness
    {
        public ReadHappiness(long requestId)
        {
            RequestId = requestId;
        }

        public long RequestId { get; }
    }
}
