using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace DragonGoL.Models.Protocol
{
    public class ReadHunger
    {
        public ReadHunger(long requestId)
        {
            RequestId = requestId;
        }

        public long RequestId { get; }
    }
}
