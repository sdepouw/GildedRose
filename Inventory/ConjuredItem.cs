namespace GildedRose.Inventory
{
    public class ConjuredItem : GildedItem
    {
        public ConjuredItem(Item item) : base(item) { }
        protected override int CalculateQualityModifier(int sellIn) => sellIn > 0 ? -2 : -4;
    }
}
