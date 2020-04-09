using GildedRoseCodeChallenge.Enums;
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
                .WithSellInValue()
                .WithQuality()
                .WithItemType();
        }

        public static Item WithSellInValue(this Item item, int sellInValue = 0)
        {
            item.SellInValue = sellInValue;
            return item;
        }

        public static Item WithQuality(this Item item, int quality = 0)
        {
            item.Quality = quality;
            return item;
        }

        public static Item WithItemType(this Item item, ItemType type = ItemType.NormalItem)
        {
            item.Type = type;
            return item;
        }
    }
}
