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
    }
}