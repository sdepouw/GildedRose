namespace GildedRose.Inventory
{
    public class SulfurasItem : GildedItem
    {
        public SulfurasItem(Item item) : base(item) { }

        protected override void UpdateQuality() { }
        protected override void UpdateSellIn() { }
    }
}
