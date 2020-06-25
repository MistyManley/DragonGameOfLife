using DragonGoL.Models.Food;
using System;
using System.Collections.Generic;
using System.Text;

namespace DragonGoL.Models.Commands
{
    public class FeedDragon
    {
        string food;
        public FeedDragon(string foodType)
        {
            food = foodType.ToLower();
        }
        public IFood Food { 
            get
            {
                if (food == Charcoal.FoodName) return new Charcoal();
                if (food == Greenery.FoodName) return new Greenery();
                else return new Steak();
            }
        }
    }
}
