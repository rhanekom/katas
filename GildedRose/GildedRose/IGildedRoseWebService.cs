using System.Collections.Generic;

namespace GildedRose
{
    public interface IGildedRoseWebService
    {
        List<Item> GetInventory();
        void SaveInventory(List<Item> items);
    }
}