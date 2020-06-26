using System;
using System.Collections.Generic;
using System.Text;

namespace DragonGoL.Models.Commands
{
    public class TextEntered
    {
        public TextEntered(string text)
        {
            Text = text;
        }

        public string Text { get; }
    }
}
