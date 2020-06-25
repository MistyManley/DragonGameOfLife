using System;
using System.Collections.Generic;
using System.Text;

namespace DragonGoL.Models.Food
{
    /// <summary>
    /// Dragons most hated food.
    /// </summary>
    public class Greenery : IFood
    {
        public static string FoodName = "greenery";
        public int HungerValue => 50;

        public int HappinessValue => -2;
    }
}
