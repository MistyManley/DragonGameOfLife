namespace DragonGoL.Models.Food
{
    /// <summary>
    /// Food type. 
    /// </summary>
    public interface IFood
    {
        int HungerValue { get; }
        int HappinessValue { get; }
    }
}
