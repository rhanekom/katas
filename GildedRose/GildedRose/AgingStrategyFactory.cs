namespace GildedRose
{
    public class AgingStrategyFactory
    {
        #region Globals

        private static readonly IAgingStrategy GetsBetterWithAgeStrategy = new GetsBetterWithAgeAgingStrategy();
        private static readonly IAgingStrategy BackStagePassAgingStrategy = new BackStagePassAgingStrategy();
        private static readonly IAgingStrategy DefaultAgingStrategy = new DefaultAgingStrategy();
        private static readonly IAgingStrategy ConjuredStrategy = new ConjuredItemsAgingStrategy();
        
        #endregion

        #region Public Members

        public IAgingStrategy Create(Item item)
        {
            if (item.GetsBetterWithAge)
            {
                return GetsBetterWithAgeStrategy;
            }

            if (item.IsBackStagePass)
            {
                return BackStagePassAgingStrategy;
            }

            if (item.IsConjuredItem)
            {
                return ConjuredStrategy;
            }

            return DefaultAgingStrategy;
        }

        #endregion
    }
}
