using GildedRose.Tests.CustomTraits;

namespace GildedRose.Tests
{
    [UnitTestTrait]
    public abstract class AppTests
    {
        protected void RunApp(params Item[] items) => new GildedRose(items).UpdateQuality();
    }
}