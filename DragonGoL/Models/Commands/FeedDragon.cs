using DragonGoL.Models.Food;

namespace DragonGoL.Models.Commands
{
    /// <summary>
    /// Console command to feed the dragon. Has a list of known foods that can be fed.
    /// </summary>
    public class FeedDragon
    {
        /// <summary>
        /// Known food types.
        /// </summary>
        public static string KnownFoods = $"{Charcoal.FoodName} {Greenery.FoodName} {Steak.FoodName}";
        string food;

        /// <summary>
        /// Creates a new <see cref="FeedDragon"/> command.
        /// </summary>
        /// <param name="foodType">A <see cref="string"/> indicating which food type to use.</param>
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
