using GildedRoseCodeChallenge.Enums;
using GildedRoseCodeChallenge.Models;
using GildedRoseCodeChallenge.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GildedRoseCodeChallenge.Services
{
    public class QualityCalculator : IQualityCalculator
    {
        public int CalculateQuality(Item item)
        {
            if (!Enum.IsDefined(typeof(ItemType), (int)item.Type))
                throw new InvalidEnumArgumentException();

            var quality = item.Quality + item.RateOfDegrade;

            if (quality < 0)
                quality = 0;

            if (quality > 50)
                quality = 50;

            return quality;
        }
    }
}
