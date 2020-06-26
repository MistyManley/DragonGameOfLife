namespace DragonGoL.Models.Commands
{
    /// <summary>
    /// A console command to return the text entered from the input.
    /// </summary>
    public class TextEntered
    {
        /// <summary>
        /// Creates a new <see cref="TextEntered"/> command with the input text value set.
        /// </summary>
        /// <param name="text">The input text value.</param>
        public TextEntered(string text)
        {
            Text = text;
        }

        public string Text { get; }
    }
}
