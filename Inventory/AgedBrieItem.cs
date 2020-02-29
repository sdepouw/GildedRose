namespace GildedRose.Inventory
{
    public class AgedBrieItem : GildedItem
    {
        public AgedBrieItem(Item item) : base(item) { }

        protected override void UpdateQuality(int sellIn)
        {
            if (sellIn > 0)
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
