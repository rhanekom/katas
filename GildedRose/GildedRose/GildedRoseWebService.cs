using System;
using System.Collections.Generic;
using System.Threading;

namespace GildedRose
{
    public class GildedRoseWebService : IGildedRoseWebService
    {
        #region Globals

        private static List<Item> inventory;

        #endregion

        #region Construction

        static GildedRoseWebService()
        {
            inventory = new List<Item>{
                                           new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                                           new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                                           new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                                           new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                                           new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80},
                                           new Item
                                               {
                                                   Name = SpecialProducts.BackstagePasses,
                                                   SellIn = 15,
                                                   Quality = 20
                                               },
                                           new Item
                                               {
                                                   Name = SpecialProducts.BackstagePasses,
                                                   SellIn = 10,
                                                   Quality = 49
                                               },
                                           new Item
                                               {
                                                   Name = SpecialProducts.BackstagePasses,
                                                   SellIn = 5,
                                                   Quality = 49
                                               },
                                           new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
                                       };

        }

        #endregion

        #region Public Members

        public List<Item> GetInventory()
        {
            //expensive call to actual webservice goes here
            Thread.Sleep(50);
            return inventory;
        }

        public void SaveInventory(List<Item> items)
        {
            //another call to webservice
            inventory = items;
            Console.WriteLine("Saved inventory at {0:dd/MM/yyyy}", DateTime.Now);
        }

        #endregion
    }
}