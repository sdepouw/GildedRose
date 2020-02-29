using System.Collections.Generic;

namespace GildedRose
{
    public class GildedRose
    {
        IList<Item> Items; // Do not mutate.
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            var gildedItems = GildedItemFactory.CreateItems(Items);
            foreach(var item in gildedItems)
            {
                item.UpdateItem();
            }
        }
    }
}
