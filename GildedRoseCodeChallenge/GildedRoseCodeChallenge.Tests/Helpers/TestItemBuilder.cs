using GildedRoseCodeChallenge.Console.Models;
using GildedRoseCodeChallenge.Enums;
using GildedRoseCodeChallenge.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRoseCodeChallenge.Tests.Helpers
{
    public static class TestItemBuilder
    {
        public static Item Build(ItemType type = ItemType.NormalItem)
        {
            Item item;
            switch (type)
            {
                case ItemType.AgedBrie:
                    item = new AgedBrie();
                    break;
                case ItemType.BackstagePasses:
                    item = new BackstagePasses();
                    break;
                case ItemType.Sulfuras:
                    item = new Sulfuras();
                    break;
                case ItemType.NormalItem:
                    item = new NormalItem();
                    break;
                case ItemType.Conjured:
                    item = new Conjured();
                    break;
                default:
                    item = new NormalItem();
                    break;
            }

            return item
                .WithSellInValue()
                .WithQuality();
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
    }
}
