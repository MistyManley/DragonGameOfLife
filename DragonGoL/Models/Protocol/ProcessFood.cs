namespace DragonGoL.Models.Protocol
{
    /// <summary>
    /// Command to tell a stomach to process food (usually increases hunger).
    /// </summary>
    public class ProcessFood
    {
        public ProcessFood(int quantityProcessed)
        {
            QuantityProcessed = quantityProcessed;
        }

        public int QuantityProcessed { get; }
    }
}
