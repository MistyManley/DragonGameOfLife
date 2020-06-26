namespace DragonGoL.Models.Commands
{
    /// <summary>
    /// Console command to play with the dragon. Has a list of known play types that can be used.
    /// </summary>
    public class PlayWithDragon
    {
        public static string KnownPlayTypes = $"games pet";
        string play;

        /// <summary>
        /// Creates a new <see cref="PlayWithDragon"/> using the supplied play type.
        /// </summary>
        /// <param name="playType">The type of play.</param>
        public PlayWithDragon(string playType)
        {
            play = playType.ToLower();
        }

        public int HappinessValue
        {
            get
            {
                if (play == "games") return 40;
                if (play == "pet") return 10;
                return 0;
            }
        }
    }
}
