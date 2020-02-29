namespace GildedRose.Inventory
{
    public class ConjuredItem : GildedItem
    {
        public ConjuredItem(Item item) : base(item) { }
        protected override int MaxQuality => int.MaxValue;

        protected override void UpdateQuality()
        {
            if (SellIn > 0)
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
