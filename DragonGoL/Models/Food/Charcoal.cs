using System;
using System.Collections.Generic;
using System.Text;

namespace DragonGoL.Models.Food
{
    /// <summary>
    /// A Dragon Treat.
    /// </summary>
    public class Charcoal : IFood
    {
        public static string FoodName = "charcoal";
        public int HungerValue => 10;

        public int HappinessValue => 4;
    }
}
