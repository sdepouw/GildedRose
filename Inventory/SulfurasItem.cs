namespace GildedRose.Inventory
{
    public class SulfurasItem : GildedItem
    {
        public SulfurasItem(Item item) : base(item) { }
        protected override int MaxQuality => int.MaxValue;

        protected override int CalculateQualityModifier(int sellIn) => 0;
        protected override void UpdateSellIn() { }
    }
}
