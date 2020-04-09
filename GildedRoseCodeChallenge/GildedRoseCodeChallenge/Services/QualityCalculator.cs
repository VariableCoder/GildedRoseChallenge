using GildedRoseCodeChallenge.Enums;
using GildedRoseCodeChallenge.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRoseCodeChallenge.Services
{
    public class QualityCalculator : IQualityCalculator
    {
        public int CalculateQuality(int sellInValue, int currentQuality, ItemType type)
        {
            var quality = currentQuality + GetRateOfDegrade(sellInValue, type);

            if (quality < 0)
                quality = 0;

            if (quality > 50)
                quality = 50;

            return quality;
        }

        private int GetRateOfDegrade(int sellInValue, ItemType type)
        {
            var rateOfDecay = 0;

            switch (type)
            {
                case ItemType.AgedBrie:
                    rateOfDecay = 1;
                    break;
                case ItemType.BackstagePasses:
                    break;
                case ItemType.Sulfuras:
                    break;
                case ItemType.NormalItem:
                    rateOfDecay = -1;
                    if (sellInValue < 0)
                        rateOfDecay *= 2;
                    break;
                case ItemType.Conjured:
                    break;
                case ItemType.InvalidItem:
                    break;
                default:
                    break;
            }

            return rateOfDecay;
        }
    }
}
