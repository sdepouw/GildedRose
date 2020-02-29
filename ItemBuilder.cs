namespace GildedRose
{
    public class ItemBuilder
    {
        private Item _item = new Item();

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
            _item.Name = "Normal";
            _item.SellIn = 10;
            _item.Quality = 15;

            return this;
        }

        public ItemBuilder AgedBrie()
        {
            _item.Name = ItemNames.AgedBrie;
            _item.SellIn = 4;
            _item.Quality = 10;

            return this;
        }

        public ItemBuilder Sulfuras()
        {
            _item.Name = ItemNames.Sulfuras;
            _item.SellIn = 3;
            _item.Quality = 80;

            return this;
        }

        public ItemBuilder BackstagePasses()
        {
            _item.Name = ItemNames.BackstagePasses;
            _item.SellIn = 20;
            _item.Quality = 3;

            return this;
        }

        public ItemBuilder Conjured()
        {
            _item.Name = $"{ItemNames.Conjured} {_item.Name}";
            _item.SellIn = 13;
            _item.Quality = 10;

            return this;
        }

        public ItemBuilder NoQuality() => Quality(0);
        public ItemBuilder MaxQuality() => Quality(50);
        public ItemBuilder SellInExpired() => SellIn(0);

        public Item Build() => _item;
    }
}
