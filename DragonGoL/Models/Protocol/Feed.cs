using DragonGoL.Models.Food;

namespace DragonGoL.Models.Protocol
{
    /// <summary>
    /// Dragon protol command to feed the dragon with food.
    /// </summary>
    public class Feed
    {
        public Feed(IFood food)
        {
            Food = food;
        }
        public IFood Food { get; }
    }
}
