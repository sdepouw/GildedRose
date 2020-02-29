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
            bool isConjured = item.Name.ContainsInsensitive(ItemNames.Conjured);
            if (item.Name.ContainsInsensitive(ItemNames.AgedBrie))
            {
                return new AgedBrieItem(item, isConjured);
            }
            if (item.Name.ContainsInsensitive(ItemNames.Sulfuras))
            {
                return new SulfurasItem(item, isConjured);
            }
            if (item.Name.ContainsInsensitive(ItemNames.BackstagePasses))
            {
                return new BackstagePassesItem(item, isConjured);
            }
            return new NormalItem(item, isConjured);
        }
    }
}
