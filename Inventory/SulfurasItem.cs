namespace GildedRose.Inventory
{
    public class SulfurasItem : GildedItem
    {
        public SulfurasItem(Item item) : base(item) { }
        protected override int MaxQuality => int.MaxValue;

        protected override void UpdateQuality() { }
        protected override void UpdateSellIn() { }
    }
}
