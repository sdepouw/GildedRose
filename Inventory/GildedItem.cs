namespace GildedRose.Inventory
{
    public abstract class GildedItem
    {
        protected readonly Item _item;

        public GildedItem(Item item) => _item = item;

        protected abstract void UpdateQuality();
        protected virtual void UpdateSellIn() => _item.SellIn--;

        public void Update()
        {
            UpdateQuality();
            UpdateSellIn();
        }
    }
}
