using GildedRose.Tests.CustomTraits;
using Xunit;

namespace GildedRose.Tests
{
    [UnitTestTrait]
    public class ConjuredItemTests
    {
        private void RunApp(params Item[] items) => new GildedRose(items).UpdateQuality();

        [Fact]
        public void ConjuredItemDegradesTwiceAsFast()
        {
            var item = new ItemBuilder().Conjured().Quality(30).Build();
            RunApp(item);
            Assert.Equal(28, item.Quality);
        }

        [Fact]
        public void ExpiredConjuredItemDegradesTwiceAsFast()
        {
            var item = new ItemBuilder().Conjured().Quality(30).SellInExpired().Build();
            RunApp(item);
            Assert.Equal(26, item.Quality);
        }

        [Fact]
        public void ConjuredBrieDoublesInQualityWhileNotExpired()
        {
            var item = new ItemBuilder().AgedBrie().Conjured().Quality(10).Build();
            RunApp(item);
            Assert.Equal(12, item.Quality);
        }

        [Fact]
        public void SulfurasRemainsImmutableDespiteConjuredStatus()
        {
            var item = new ItemBuilder().Sulfuras().Conjured().Quality(99).SellIn(-5).Build();
            RunApp(item);
            Assert.Equal(99, item.Quality);
            Assert.Equal(-5, item.SellIn);
        }

        [Fact]
        public void ConjuredBackstagePassesHaveQualityIncreaseOf6NearConcertDate()
        {
            var item = new ItemBuilder().BackstagePasses().Conjured().Quality(40).SellIn(2).Build();
            RunApp(item);
            Assert.Equal(46, item.Quality);
        }
    }
}