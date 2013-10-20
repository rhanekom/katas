namespace GildedRose
{
    public class DefaultAgingStrategy : IAgingStrategy
    {
        #region IAgingStrategy Members

        public void Apply(Item item)
        {
            item.DecreaseQuality();
            item.DecreaseSellIn();

            if (item.IsExpired)
            {
                item.DecreaseQuality();
            }
        }

        #endregion
    }
}