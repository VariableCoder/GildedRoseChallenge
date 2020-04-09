using GildedRoseCodeChallenge.Models;
using GildedRoseCodeChallenge.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GildedRoseCodeChallenge.Services
{
    public class InventoryService : IInventoryService
    {
        private IQualityCalculator _qualityCalculator;

        public InventoryService(IQualityCalculator qualityCalculator)
        {
            _qualityCalculator = qualityCalculator;
        }

        public void UpdateInventory(Item item)
        {
                item.SellInValue = CalculateSellInValue(item);
                item.Quality = _qualityCalculator.CalculateQuality(item);
        }

        private int CalculateSellInValue(Item item)
        {
            if (item.Type == Enums.ItemType.Sulfuras)
                return item.SellInValue;

            return item.SellInValue - 1;
        }
    }
}
