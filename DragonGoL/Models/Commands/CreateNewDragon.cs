using System;
using System.Collections.Generic;
using System.Text;

namespace DragonGoL.Models.Commands
{
    public class CreateNewDragon
    {
        public CreateNewDragon(string type, string name, int weight)
        {
            DragonType = type;
            Name = name;
            Weight = weight;
        }

        public string DragonType { get; }
        public string Name { get; }
        public int Weight { get; }
    }
}
