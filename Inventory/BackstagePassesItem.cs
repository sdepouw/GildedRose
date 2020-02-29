namespace GildedRose.Inventory
{
    public class BackstagePassesItem : GildedItem
    {
        public BackstagePassesItem(Item item) : base(item) { }

        protected override void UpdateQuality()
        { 
            Quality++;
            if (SellIn <= 10)
            {
                Quality++;
            }
            if (SellIn <= 5)
            {
                Quality++;
            }
            if (SellIn <= 0)
            {
                Quality = 0;
            }
        }
    }
}
