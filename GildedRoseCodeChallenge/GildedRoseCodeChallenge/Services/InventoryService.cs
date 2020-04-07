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
        public void UpdateInventory(IEnumerable<Item> items)
        {
            items.ToList().ForEach(x => UpdateSellInValue(x));
        }

        private void UpdateSellInValue(Item item)
        {
            item.SellInValue = DateTime.Now.Subtract(item.SellByDate).Days;
        }
    }
}
