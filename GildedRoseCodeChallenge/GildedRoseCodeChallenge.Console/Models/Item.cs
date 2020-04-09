using GildedRoseCodeChallenge.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRoseCodeChallenge.Models
{
    public class Item
    {
        public int SellInValue { get; set; }
        public int Quality { get; set; }
        public ItemType Type { get; set; }
    }
}
