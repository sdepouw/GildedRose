namespace GildedRose.Inventory
{
    public class AgedBrieItem : GildedItem
    {
        public AgedBrieItem(Item item) : base(item) { }

        protected override void UpdateQuality()
        {
            if (SellIn > 0)
            {
                Quality++;
            }
            else
            {
                Quality += 2;
            }
        }
    }
}
