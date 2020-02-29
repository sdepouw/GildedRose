namespace GildedRose.Inventory
{
    public class BackstagePassesItem : GildedItem
    {
        public BackstagePassesItem(Item item) : base(item) { }

        protected override void UpdateQuality()
        { 
            if (SellIn <= 10)
            {
                Quality += 2;
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
