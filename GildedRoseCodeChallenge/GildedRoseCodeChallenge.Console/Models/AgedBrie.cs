using GildedRoseCodeChallenge.Enums;
using GildedRoseCodeChallenge.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRoseCodeChallenge.Console.Models
{
    public class AgedBrie : Item
    {
        public override int RateOfDegrade => 1;
        public override ItemType Type => ItemType.AgedBrie;
    }
}
