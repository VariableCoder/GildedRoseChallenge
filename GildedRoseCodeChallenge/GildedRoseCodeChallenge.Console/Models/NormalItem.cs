using GildedRoseCodeChallenge.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRoseCodeChallenge.Console.Models
{
    public class NormalItem : Item
    {
        public override int RateOfDegrade => SellInValue >= 0 ? -1 : -2;
    }
}
