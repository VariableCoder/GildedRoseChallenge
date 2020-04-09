using GildedRoseCodeChallenge.Enums;
using GildedRoseCodeChallenge.Models;
using GildedRoseCodeChallenge.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRoseCodeChallenge
{
    public class Application
    {
        private readonly IInventoryService _inventoryService;
        public Application(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        public void Run() {
            var items = new Item[]
            {
                new Item(){ Type = ItemType.AgedBrie, SellInValue = 1, Quality = 1 }
            };
        }
    }
}
