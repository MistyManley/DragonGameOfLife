using DragonGoL.Models.Food;
using System;
using System.Collections.Generic;
using System.Text;

namespace DragonGoL.Models.Protocol
{
    class Feed
    {
        public Feed(IFood food)
        {
            Food = food;
        }
        public IFood Food { get; }
    }
}
