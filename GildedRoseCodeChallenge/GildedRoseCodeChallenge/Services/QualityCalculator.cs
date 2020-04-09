using GildedRoseCodeChallenge.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRoseCodeChallenge.Services
{
    public class QualityCalculator : IQualityCalculator
    {
        public int CalculateQuality(int sellInValue, int currentQuality)
        {
            var quality = currentQuality;
            if (quality < 0)
                quality = 0;

            if (quality > 50)
                quality = 50;

            return quality;
        }
    }
}
