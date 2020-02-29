using System.Collections.Generic;
using System.Linq;
using GildedRose.Inventory;

namespace GildedRose
{
    public static class GildedItemFactory
    {
        public static IEnumerable<GildedItem> CreateItems(IEnumerable<Item> items) => items.Select(item => GetItem(item));

        private static GildedItem GetItem(Item item)
        {
            switch(item.Name)
            {
                case ItemNames.AgedBrie:
                    return new AgedBrieItem(item);
                case ItemNames.Sulfuras:
                    return new SulfurasItem(item);
                case ItemNames.BackstagePasses:
                    return new BackstagePassesItem(item);
                default:
                    return new NormalItem(item);
            }
        }
    }
}
