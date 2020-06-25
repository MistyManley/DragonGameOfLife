using System;
using System.Collections.Generic;
using System.Text;

namespace DragonGoL.Models.Protocol
{
    class Play
    {
        public Play(int happinessValue)
        {
            HappinessValue = happinessValue;
        }
        public int HappinessValue { get; }
    }
}
