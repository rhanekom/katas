namespace GildedRose
{
    public class GetsBetterWithAgeAgingStrategy : IAgingStrategy
    {
        #region IAgingStrategy Members

        public void Apply(Item item)
        {
            item.IncreaseQuality();
            item.DecreaseSellIn();

            if (item.IsExpired)
            {
                item.IncreaseQuality();
            }
        }

        #endregion
    }
}