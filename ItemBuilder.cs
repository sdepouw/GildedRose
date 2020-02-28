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
            _item.Quality = 100;

            return this;
        }

        public ItemBuilder AgedBrie()
        {
            _item.Name = "Aged Brie";
            _item.SellIn = 4;
            _item.Quality = 10;

            return this;
        }

        public ItemBuilder Sulfuras()
        {
            _item.Name = "Sulfuras, Hand of Ragnaros";
            _item.SellIn = 3;
            _item.Quality = 30;

            return this;
        }

        public ItemBuilder BackstagePasses()
        {
            _item.Name = "Backstage passes to a TAFKAL80ETC concert";
            _item.SellIn = 9;
            _item.Quality = 40;

            return this;
        }

        public ItemBuilder NoQuality() => Quality(0);
        public ItemBuilder SellInExpired() => SellIn(0);

        public Item Build() => _item;
    }
}

/*

        public static ItemName Sulfuras = new ItemName("Sulfuras");
        public static ItemName BackstagePasses = new ItemName("Backstage passes");

*/