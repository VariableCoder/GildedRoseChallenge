using GildedRoseCodeChallenge.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRoseCodeChallenge.Console.Models
{
    public class Conjured : Item
    {
        public override int RateOfDegrade => new NormalItem() { Quality = this.Quality, SellInValue = this.SellInValue }.RateOfDegrade * 2;
    }
}
