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
            items.ToList().ForEach(x => { 
                UpdateSellInValue(x);
                x.Quality = _qualityCalculator.CalculateQuality(x);
            });
        }

        private void UpdateSellInValue(Item item)
        {
            item.SellInValue = DateTime.Now.Subtract(item.SellByDate).Days;
        }
    }
}
