using System;
using System.Collections.Generic;
using System.Text;

namespace DragonGoL.Models.Protocol
{
    public class ProcessFood
    {
        public ProcessFood(int quantityProcessed)
        {
            QuantityProcessed = quantityProcessed;
        }

        public int QuantityProcessed { get; }
    }
}
