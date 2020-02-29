using System;

namespace GildedRose.Inventory
{
    public class NormalItem : GildedItem
    {
        public NormalItem(Item item) : base(item) { }

        protected override void UpdateQuality()
        {
            if (_item.SellIn > 0)
            {
                _item.Quality--;
            }
            else
            {
                _item.Quality -= 2;
            }
            _item.Quality = Math.Max(0, Math.Min(50, _item.Quality));
        }
    }
}
