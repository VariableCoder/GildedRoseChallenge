using GildedRoseCodeChallenge.Enums;
using GildedRoseCodeChallenge.Models;
using GildedRoseCodeChallenge.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
                new Item(){ Type = ItemType.AgedBrie, SellInValue = 1, Quality = 1 },
                new Item(){ Type = ItemType.BackstagePasses, SellInValue = -1, Quality = 2},
                new Item(){ Type = ItemType.BackstagePasses, SellInValue = 9, Quality = 2},
                new Item(){ Type = ItemType.Sulfuras, SellInValue = 2, Quality = 2},
                new Item(){ Type = ItemType.NormalItem, SellInValue = -1, Quality = 55},
                new Item(){ Type = ItemType.NormalItem, SellInValue = 2, Quality = 2},
                new Item(){ Type = (ItemType)17, SellInValue = 2, Quality = 2},
                new Item(){ Type = ItemType.Conjured, SellInValue = 2, Quality = 2},
                new Item(){ Type = ItemType.Conjured, SellInValue = -1, Quality = 5}
            };

            items.ToList().ForEach(item =>
            {
                try
                {
                    _inventoryService.UpdateInventory(item);
                    Console.WriteLine($"{item.Type} {item.SellInValue} {item.Quality}");
                }
                catch (InvalidEnumArgumentException ex)
                {
                    Console.WriteLine("NO SUCH ITEM");
                }
            });

            Console.WriteLine("Press any key to exit the application : ");
            Console.ReadKey();
        }
    }
}
