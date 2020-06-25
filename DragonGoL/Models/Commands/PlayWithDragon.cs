using System;
using System.Collections.Generic;
using System.Text;

namespace DragonGoL.Models.Commands
{
    public class PlayWithDragon
    {
        string play;
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
