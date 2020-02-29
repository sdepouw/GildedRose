using System;

namespace GildedRose.Inventory
{
    public class BackstagePassesItem : GildedItem
    {
        public BackstagePassesItem(Item item) : base(item) { }

        protected override void UpdateQuality()
        { 
            if (_item.SellIn <= 10)
            {
                _item.Quality += 2;
            }
            if (_item.SellIn <= 5)
            {
                _item.Quality++;
            }
            if (_item.SellIn <= 0)
            {
                _item.Quality = 0;
            }

            _item.Quality = Math.Max(0, Math.Min(50, _item.Quality));
        }
    }
}
