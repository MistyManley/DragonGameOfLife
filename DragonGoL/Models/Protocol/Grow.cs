using System;
using System.Collections.Generic;
using System.Text;

namespace DragonGoL.Models.Protocol
{
    public class Grow
    {
        public Grow(decimal daysPassed)
        {
            DaysToGrow = daysPassed;
        }

        public decimal DaysToGrow { get; }
    }
}
