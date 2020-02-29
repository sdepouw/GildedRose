namespace GildedRose.Inventory
{
    public class SulfurasItem : GildedItem
    {
        public SulfurasItem(Item item) : base(item) { }
        protected override int MaxQuality => int.MaxValue;

        protected override void UpdateQuality(int sellIn) { }
        protected override void UpdateSellIn() { }
    }
}
