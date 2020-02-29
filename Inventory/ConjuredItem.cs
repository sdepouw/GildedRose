namespace GildedRose.Inventory
{
    public class ConjuredItem : GildedItem
    {
        public ConjuredItem(Item item) : base(item) { }
        protected override int MaxQuality => int.MaxValue;

        protected override void UpdateQuality(int sellIn)
        {
            if (sellIn > 0)
            {
                Quality -= 2;
            }
            else
            {
                Quality -= 4;
            }
        }
    }
}
