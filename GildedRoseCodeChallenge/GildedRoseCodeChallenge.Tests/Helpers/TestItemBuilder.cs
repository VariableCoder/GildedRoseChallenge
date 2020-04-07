using GildedRoseCodeChallenge.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRoseCodeChallenge.Tests.Helpers
{
    public static class TestItemBuilder
    {
        public static Item Build()
        {
            return new Item()
                .WithSellByDate();
        }

        public static Item WithSellByDate(this Item item, DateTime sellByDate = default)
        {
            item.SellByDate = sellByDate;
            return item;
        }

        public static Item WithQuality(this Item item, int quality = 0)
        {
            item.Quality = quality;
            return item;
        }
    }
}
