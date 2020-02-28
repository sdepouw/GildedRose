using Xunit;

namespace GildedRose
{
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
            var item = new ItemBuilder().AgedBrie().Quality(30).Build();
            GetApp(item).UpdateQuality();
            Assert.Equal(31, item.Quality);
        }
    }
}