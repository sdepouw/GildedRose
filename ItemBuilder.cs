namespace GildedRose
{
    public class ItemBuilder
    {
        private Item _item = new Item();

        public ItemBuilder Name(ItemName name)
        {
            _item.Name = name;
            return this;
        }

        public ItemBuilder Quality(int quality)
        {
            _item.Quality = quality;
            return this;
        }

        public ItemBuilder SellIn(int sellIn)
        {
            _item.SellIn = sellIn;
            return this;
        }

        public ItemBuilder Normal()
        {
            _item.Name = ItemName.Normal;
            _item.SellIn = 10;
            _item.Quality = 100;

            return this;
        }

        public ItemBuilder NoQuality() => Quality(0);
        public ItemBuilder SellInExpired() => SellIn(0);

        public Item Build() => _item;
    }
}