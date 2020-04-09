using GildedRoseCodeChallenge.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRoseCodeChallenge.Services
{
    public class QualityCalculator : IQualityCalculator
    {
        private int _rateOfDegrade = -1;
        public int CalculateQuality(int sellInValue, int currentQuality)
        {
            var quality = currentQuality + _rateOfDegrade;
            if (quality < 0)
                quality = 0;

            if (quality > 50)
                quality = 50;

            return quality;
        }
    }
}
