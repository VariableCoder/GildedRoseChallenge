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
        private IDateTimeProvider _dateTimeProvider;

        public InventoryService(IQualityCalculator qualityCalculator, IDateTimeProvider dateTimeProvider)
        {
            _qualityCalculator = qualityCalculator;
            _dateTimeProvider = dateTimeProvider;
        }

        public void UpdateInventory(IEnumerable<Item> items)
        {
            items.ToList().ForEach(item =>
            {
                item.SellInValue = CalculateSellInValue(item);
                item.Quality = _qualityCalculator.CalculateQuality(item.SellInValue, item.Quality);
            });
        }

        private int CalculateSellInValue(Item item)
        {
            return _dateTimeProvider.GetCurrentDateTime().Subtract(item.SellByDate).Days;
        }
    }
}
