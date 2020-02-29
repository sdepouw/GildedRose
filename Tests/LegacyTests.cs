using System;
using System.Linq;
using Xunit;

namespace GildedRose.Tests
{
    [Trait("Category", "Unit")]
    public class LegacyTests
    {
        private void RunApp(params Item[] items) => new GildedRose(items).UpdateQuality();

        [Fact]
        public void QualityCannotGoNegative()
        {
            var items = OneOfEach();
            RunApp(items);
            AssertAll(items, item => item.Quality >= 0, "Some items dropped to negative quality!");
        }

        [Fact]
        public void QualityCannotExceed50()
        {
            var items = OneOfEach();
            RunApp(items);
            AssertAll(items, item => item.Quality <= 50, "Some items exceeded max quality!");
        }

        [Fact]
        public void NormalItemDecreasesInQualityEachDay()
        {
            var item = new ItemBuilder().Normal().Quality(49).Build();
            RunApp(item);
            Assert.Equal(48, item.Quality);
        }

        [Fact]
        public void NormalItemDegradesTwiceAsFastAfterSellInPassed()
        {
            var item = new ItemBuilder().Normal().Quality(35).SellInExpired().Build();
            RunApp(item);
            Assert.Equal(33, item.Quality);
        }

        [Fact]
        public void AgedBrieQualityIncreasesWithAge()
        {
            var item = new ItemBuilder().AgedBrie().Quality(30).Build();
            RunApp(item);
            Assert.Equal(31, item.Quality);
        }

        [Fact]
        public void AgedBrieQualityIncreasesDoublyAfterSellIn()
        {
            var item = new ItemBuilder().AgedBrie().Quality(30).SellInExpired().Build();
            RunApp(item);
            Assert.Equal(32, item.Quality);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(1)]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-10)]
        public void SulfurasQualityNeverChanges(int sellIn)
        {
            var item = new ItemBuilder().Sulfuras().SellIn(sellIn).Build();
            int expectedQuality = item.Quality;
            RunApp(item);
            Assert.Equal(expectedQuality, item.Quality);
        }

        [Fact]
        public void SulfurasSellInNeverChanges()
        {
            var item = new ItemBuilder().Sulfuras().SellIn(15).Build();
            RunApp(item);
            Assert.Equal(15, item.SellIn);
        }

        [Fact]
        public void BackstagePassesQualityIncreaseWithAge()
        {
            var item = new ItemBuilder().BackstagePasses().Quality(10).Build();
            RunApp(item);
            Assert.Equal(11, item.Quality);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(9)]
        [InlineData(8)]
        [InlineData(7)]
        [InlineData(6)]
        public void BackstagePassesGetDoubleQualityWithin10DaysOfEvent(int sellIn)
        {
            var item = new ItemBuilder().BackstagePasses().Quality(30).SellIn(sellIn).Build();
            RunApp(item);
            Assert.Equal(32, item.Quality);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(4)]
        [InlineData(3)]
        [InlineData(2)]
        [InlineData(1)]
        public void BackstagePassesGetTripleQualityWithin5DaysOfEvent(int sellIn)
        {
            var item = new ItemBuilder().BackstagePasses().Quality(20).SellIn(sellIn).Build();
            RunApp(item);
            Assert.Equal(23, item.Quality);
        }

        [Fact]
        public void BackstagePassesAreWorthlessAfterSellInExpires()
        {
            var item = new ItemBuilder().BackstagePasses().SellInExpired().Build();
            RunApp(item);
            Assert.Equal(0, item.Quality);
        }

        private void AssertAll(Item[] items, Func<Item, bool> testFunc, string message)
        {
            Assert.True(items.All(testFunc), $"{message} {string.Join(", ", items.Where(item => item.Quality > 50).Select(item => item.Name))}");
        }

        private Item[] OneOfEach()
        {
            var normal = new ItemBuilder().Normal().MaxQuality().Build();
            var agedBrie = new ItemBuilder().AgedBrie().MaxQuality().Build();
            var sulfuras = new ItemBuilder().Sulfuras().MaxQuality().Build();
            var backstage = new ItemBuilder().BackstagePasses().MaxQuality().Build();
            return new[] { normal, agedBrie, sulfuras, backstage };
        }
    }
}