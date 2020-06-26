namespace DragonGoL.Models.Commands
{
    /// <summary>
    /// Console command used to create a new dragon.
    /// </summary>
    public class CreateNewDragon
    {
        /// <summary>
        /// Creates a new <see cref="CreateNewDragon"/> command with a specified type, name and weight.
        /// </summary>
        /// <param name="type">The type of dragon to create.</param>
        /// <param name="name">The dragons name.</param>
        /// <param name="weight">The intial weight of the dragon.</param>
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
