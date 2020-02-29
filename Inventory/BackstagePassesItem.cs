namespace GildedRose.Inventory
{
    public class BackstagePassesItem : GildedItem
    {
        public BackstagePassesItem(Item item) : base(item) { }

        protected override void UpdateQuality(int sellIn)
        { 
            Quality++;
            if (sellIn <= 10)
            {
                Quality++;
            }
            if (sellIn <= 5)
            {
                Quality++;
            }
            if (sellIn <= 0)
            {
                Quality = 0;
            }
        }
    }
}
