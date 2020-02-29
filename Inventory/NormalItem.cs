namespace GildedRose.Inventory
{
    public class NormalItem : GildedItem
    {
        public NormalItem(Item item) : base(item) { }

        protected override void UpdateQuality(int sellIn)
        {
            if (sellIn > 0)
            {
                Quality--;
            }
            else
            {
                Quality -= 2;
            }
        }
    }
}
