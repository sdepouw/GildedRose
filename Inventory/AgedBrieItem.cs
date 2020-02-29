namespace GildedRose.Inventory
{
    public class AgedBrieItem : GildedItem
    {
        public AgedBrieItem(Item item) : base(item) { }
        protected override int CalculateQualityModifier(int sellIn) => sellIn > 0 ? 1 : 2;
    }
}
