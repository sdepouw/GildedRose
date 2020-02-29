using System;

namespace GildedRose.Inventory
{
    public abstract class GildedItem
    {
        private readonly Item _item;
        private readonly bool _isConjured;

        private int Quality
        {
            get => _item.Quality;
            set => _item.Quality = Math.Max(0, Math.Min(MaxQuality, value));
        }

        public GildedItem(Item item, bool isConjured)
        {
            _item = item;
            _isConjured = isConjured;
        }

        protected virtual int MaxQuality => 50;
        protected abstract int CalculateQualityModifier(int sellIn);
        protected virtual void UpdateSellIn() => _item.SellIn--;

        public void Update()
        {
            int qualityModifier = CalculateQualityModifier(_item.SellIn);

            // HACK: -int.MaxValue means "set to 0" basically.
            if (_isConjured && qualityModifier != -int.MaxValue)
            {
                qualityModifier *= 2;
            }
            Quality += qualityModifier;

            UpdateSellIn();
        }
    }
}
