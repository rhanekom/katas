using System.Collections.Generic;

namespace GildedRose
{
    public interface IGildedRoseWebService
    {
        List<Item> GetInventory(string uri);
        void SaveInventory(string uri, List<Item> items);
    }
}