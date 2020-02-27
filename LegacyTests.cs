using Xunit;

namespace GildedRose
{
    public sealed class ItemName
    {
        public static ItemName Normal = new ItemName("Normal");
        public static ItemName AgedBrie = new ItemName("Aged Brie");
        public static ItemName Sulfuras = new ItemName("Sulfuras");
        public static ItemName BackstagePasses = new ItemName("Backstage passes");

        private readonly string _name;

        public ItemName(string name) => _name = name;

        public static implicit operator string(ItemName name) => name._name;
    }

    public class LegacyTests
    {
        private GildedRose GetApp(params Item[] items) => new GildedRose(items);

        [Fact]
        public void NormalItemDecreasesInQualityEachDay()
        {
            var item = new ItemBuilder().Normal().Quality(75).Build();
            GetApp(item).UpdateQuality();
            Assert.Equal(74, item.Quality);
        }

        [Fact]
        public void NormalItemDegradesTwiceAsFastAfterSellInPassed()
        {
            var item = new ItemBuilder().Normal().Quality(35).SellInExpired().Build();
            GetApp(item).UpdateQuality();
            Assert.Equal(33, item.Quality);
        }

        [Fact]
        public void ItemQualityCannotGoNegative()
        {
            var item = new ItemBuilder().Normal().NoQuality().Build();
            GetApp(item).UpdateQuality();
            Assert.Equal(0, item.Quality);
        }

        [Fact]
        public void AgedBrieIncreasesWithAge()
        {
            var item = new ItemBuilder().Name(ItemName.AgedBrie).Quality(77).SellIn(10).Build();
            GetApp(item).UpdateQuality();
            Assert.Equal(78, item.Quality);
        }
    }
}