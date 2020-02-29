namespace GildedRose.Inventory
{
    public class NormalItem : GildedItem
    {
        public NormalItem(Item item) : base(item) { }
        protected override int CalculateQualityModifier(int sellIn) => sellIn > 0 ? -1 : -2;
    }
}
