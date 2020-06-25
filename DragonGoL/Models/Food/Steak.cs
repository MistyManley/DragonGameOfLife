using System;
using System.Collections.Generic;
using System.Text;

namespace DragonGoL.Models.Food
{
    /// <summary>
    /// Dragons staple food.
    /// </summary>
    public class Steak : IFood
    {
        public static string FoodName = "steak";
        public int HungerValue => 20;

        public int HappinessValue => 0;
    }
}
