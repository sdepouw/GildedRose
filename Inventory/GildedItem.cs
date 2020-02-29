using System;

namespace GildedRose.Inventory
{
    public abstract class GildedItem
    {
        private readonly Item _item;

        private int Quality
        { 
            get => _item.Quality;
            set => _item.Quality = Math.Max(0, Math.Min(MaxQuality, value));
        }
        
        public GildedItem(Item item) => _item = item;

        protected virtual int MaxQuality => 50;
        protected abstract int CalculateQualityModifier(int sellIn);
        protected virtual void UpdateSellIn() => _item.SellIn--;

        public void Update()
        {
            int qualityModifier = CalculateQualityModifier(_item.SellIn);
            Quality += qualityModifier;
            UpdateSellIn();
        }
    }
}
