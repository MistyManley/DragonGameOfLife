using System;
using System.Collections.Generic;
using System.Text;

namespace DragonGoL.Models.Commands
{
    public class DragonCreated
    {
        public static DragonCreated Instance { get; } = new DragonCreated();
        private DragonCreated() { }
    }
}
