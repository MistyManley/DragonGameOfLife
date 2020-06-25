using DragonGoL.Models.Food;
using System;
using System.Collections.Generic;
using System.Text;

namespace DragonGoLTests
{
    public class TestFood : IFood
    {
        public TestFood(int hungerValue, int happinessValue)
        {
            HungerValue = hungerValue;
            HappinessValue = happinessValue;
        }

        public int HungerValue { get; }

        public int HappinessValue { get;}
    }
}
