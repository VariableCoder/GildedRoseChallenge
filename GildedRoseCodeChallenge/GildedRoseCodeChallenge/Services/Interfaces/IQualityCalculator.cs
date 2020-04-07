using GildedRoseCodeChallenge.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRoseCodeChallenge.Services.Interfaces
{
    public interface IQualityCalculator
    {
        void UpdateQuality(IEnumerable<Item> inventoryItems);
        int CalculateQuality(Item inventoryItem);
    }
}
