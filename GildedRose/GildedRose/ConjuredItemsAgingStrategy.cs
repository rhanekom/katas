namespace GildedRose
{
    public class ConjuredItemsAgingStrategy : IAgingStrategy
    {
        #region IAgingStrategy Members

        public void Apply(Item item)
        {
            DecreaseQuality(item);

            item.DecreaseSellIn();

            if (item.IsExpired)
            {
                DecreaseQuality(item);
            }
        }

        #endregion

        #region Private Members

        private void DecreaseQuality(Item item)
        {
            item.DecreaseQuality();
            item.DecreaseQuality();
        }

        #endregion
    }
}
