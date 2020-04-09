using GildedRoseCodeChallenge.Enums;
using GildedRoseCodeChallenge.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRoseCodeChallenge.Services.Interfaces
{
    public interface IQualityCalculator
    {
        int CalculateQuality(Item item);
    }
}
