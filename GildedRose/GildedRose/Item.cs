namespace GildedRose
{
    public class Item
    {
        #region Globals

        private const int MaxQuality = 50;

        #endregion

        #region Public Members

        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }

        public bool IsExpired
        {
            get
            {
                return SellIn < 0;
            }
        }

        public bool IsLegendaryProduct
        {
            get
            {
                return Name == SpecialProducts.Sulfuras;
            }
        }

        public bool IsBackStagePass
        {
            get
            {
                return Name == SpecialProducts.BackstagePasses;
            }
        }

        public bool GetsBetterWithAge
        {
            get
            {
                return Name == SpecialProducts.AgedBrie;
            }
        }

        public void ResetQuality()
        {
            Quality = 0;
        }

        public void DecreaseQuality()
        {
            if (CanDecreaseQuality)
            {
                Quality -= 1;
            }
        }

        public void DecreaseSellIn()
        {
            if (CanDecreaseSellin)
            {
                SellIn -= 1;
            }
        }

        public void IncreaseQuality()
        {
            if (CanIncreaseQuality)
            {
                Quality += 1;
            }
        }

        #endregion

        #region Private Members

        private bool CanDecreaseQuality
        {
            get
            {
                return Quality > 0 && !IsLegendaryProduct;
            }
        }

        private bool CanIncreaseQuality
        {
            get
            {
                return Quality < MaxQuality;
            }
        }

        private bool CanDecreaseSellin
        {
            get
            {
                return !IsLegendaryProduct;
            }
        }

        public bool IsConjuredItem
        {
            get
            {
                return Name == SpecialProducts.Conjured;
            }
        }

        #endregion
    }
}