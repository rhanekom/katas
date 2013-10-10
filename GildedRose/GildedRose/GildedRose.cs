using System;
using System.Collections;

namespace GildedRose
{
	public class GildedRose
	{	    

	    public void UpdateQuality()
	    {
	        var uri = "http://www.gildrose.co.za/api/inventory";
		    var items = GildedRoseWebService.GetInventory(uri);
			for (var i = 0; i < items.Count; i++)
			{
				if (items[i].Name != "Aged Brie" && items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
				{
					if (items[i].Quality > 0)
					{
						if (items[i].Name != "Sulfuras, Hand of Ragnaros")
						{
							items[i].Quality = items[i].Quality - 1;
						}
					}
				}
				else
				{
					if (items[i].Quality < 50)
					{
						items[i].Quality = items[i].Quality + 1;
						
						if (items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
						{
							if (items[i].SellIn < 11)
							{
								if (items[i].Quality < 50)
								{
									items[i].Quality = items[i].Quality + 1;
								}
							}
							
							if (items[i].SellIn < 5)
							{
								if (items[i].Quality < 50)
								{
									items[i].Quality = items[i].Quality + 1;
								}
							}
						}
					}
				}
				
				if (items[i].Name != "Sulfuras, Hand of Ragnaros")
				{
					items[i].SellIn = items[i].SellIn - 1;
				}
				
				if (items[i].SellIn < 0)
				{
					if (items[i].Name != "Aged Brie")
					{
						if (items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
						{
							if (items[i].Quality > 0)
							{
								if (items[i].Name != "Sulfuras, Hand of Ragnaros")
								{
									items[i].Quality = items[i].Quality - 1;
								}
							}
						}
						else
						{
							items[i].Quality = items[i].Quality - items[i].Quality;
						}
					}
					else
					{
						if (items[i].Quality < 50)
						{
							items[i].Quality = items[i].Quality + 1;
						}
					}
				}
			}

	        GildedRoseWebService.SaveInventory(uri, items);
	    }

	    public void PrintReport()
	    {
	        var items = GildedRoseWebService.GetInventory("http://www.gildedrose.co.za/api/inventory/");
	        Console.WriteLine("name, sellIn, quality");
	        for (var j = 0; j < items.Count; j++)
	        {
	            Console.WriteLine(items[j].Name + ", " + items[j].SellIn + ", " + items[j].Quality);
	        }
	        Console.WriteLine("");
	    }
	}


    public class Item
	{
		public string Name { get; set; }
		
		public int SellIn { get; set; }
		
		public int Quality { get; set; }
	}
	
}
