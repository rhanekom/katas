namespace GildedRose
{
    public class BackStagePassAgingStrategy : IAgingStrategy
    {
        #region IAgingStrategy Members

        public void Apply(Item item)
        {
            IncreaseQuality(item);

            item.DecreaseSellIn();

            if (item.IsExpired)
            {
                item.ResetQuality();
            }
        }
        
        #endregion

        #region Private Members

        private static void IncreaseQuality(Item item)
        {
            item.IncreaseQuality();

            if (item.SellIn < 11)
            {
                item.IncreaseQuality();
            }

            if (item.SellIn <= 5)
            {
                item.IncreaseQuality();
            }
        }

        #endregion
    }
}