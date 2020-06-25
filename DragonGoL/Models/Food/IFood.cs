using System;
using System.Collections.Generic;
using System.Text;

namespace DragonGoL.Models.Food
{
    public interface IFood
    {
        int HungerValue { get; }
        int HappinessValue { get; }
    }
}
