using System;
using System.Linq;
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
            var items = OneOfEach();
            GetApp(items).UpdateQuality();
            AssertAll(items, item => item.Quality >= 0, "Some items dropped to negative quality!");
        }

        [Fact]
        public void AgedBrieIncreasesWithAge()
        {
            var item = new ItemBuilder().AgedBrie().Quality(30).Build();
            GetApp(item).UpdateQuality();
            Assert.Equal(31, item.Quality);
        }

        [Fact]
        public void QualityCannotExceed50()
        {
            var items = OneOfEach();
            GetApp(items).UpdateQuality();
            AssertAll(items, item => item.Quality <= 50, "Some items exceeded max quality!");
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