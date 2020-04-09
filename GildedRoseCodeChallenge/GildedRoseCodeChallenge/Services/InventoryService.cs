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

        public void UpdateInventory(IEnumerable<Item> items)
        {
            items.ToList().ForEach(item =>
            {
                item.SellInValue = CalculateSellInValue(item);
                item.Quality = _qualityCalculator.CalculateQuality(item.SellInValue, item.Quality, item.Type);
            });
        }

        private int CalculateSellInValue(Item item)
        {
            return item.SellInValue - 1;
        }
    }
}
