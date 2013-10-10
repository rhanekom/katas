using System;
using System.Collections.Generic;
using System.Threading;

namespace GildedRose
{
    public class GildedRoseWebService
    {
        private static List<Item> _inventory; 

        static GildedRoseWebService()
        {
            _inventory = new List<Item>{
                                           new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                                           new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                                           new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                                           new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                                           new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80},
                                           new Item
                                               {
                                                   Name = "Backstage passes to a TAFKAL80ETC concert",
                                                   SellIn = 15,
                                                   Quality = 20
                                               },
                                           new Item
                                               {
                                                   Name = "Backstage passes to a TAFKAL80ETC concert",
                                                   SellIn = 10,
                                                   Quality = 49
                                               },
                                           new Item
                                               {
                                                   Name = "Backstage passes to a TAFKAL80ETC concert",
                                                   SellIn = 5,
                                                   Quality = 49
                                               },
                                           new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
                                       };

        }

        public static  List<Item> GetInventory(string uri)
        {
            //expensive call to actual webservice goes here
            Thread.Sleep(50);
            return _inventory;
        }

        public static void SaveInventory(string uri, List<Item> items)
        {
            //another call to webservice
            _inventory = items;
            Console.WriteLine("Saved inventory at {0:dd/MM/yyyy}", DateTime.Now);
        }
    }
}