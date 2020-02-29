namespace GildedRose.Inventory
{
    public class NormalItem : GildedItem
    {
        public NormalItem(Item item) : base(item) { }

        protected override void UpdateQuality()
        {
            if (SellIn > 0)
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
