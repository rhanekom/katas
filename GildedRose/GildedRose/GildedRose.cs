namespace GildedRose
{
    using System;

    public class GildedRose
    {
        #region Globals

        private readonly IGildedRoseWebService webService;

        #endregion

        #region Construction

        public GildedRose(IGildedRoseWebService webService)
        {
            this.webService = webService;
        }

        #endregion

        #region Public Members

        public void UpdateQuality()
        {
            var items = webService.GetInventory();
            var agingStrategy = new AgingStrategyFactory();
            
            foreach (Item item in items)
            {
                IAgingStrategy strategy = agingStrategy.Create(item);
                strategy.Apply(item);
            }

            webService.SaveInventory(items);
        }

        public void PrintReport()
        {
            var items = webService.GetInventory();
            Console.WriteLine("name, sellIn, quality");
            foreach (Item item in items)
            {
                Console.WriteLine("{0}, {1}, {2}", item.Name, item.SellIn, item.Quality);
            }

            Console.WriteLine();
        }

        #endregion
    }
}