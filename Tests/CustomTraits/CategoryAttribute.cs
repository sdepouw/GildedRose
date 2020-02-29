using System;
using Xunit.Sdk;

namespace GildedRose.Tests.CustomTraits
{
    [TraitDiscoverer("GildedRose.Tests.CustomTraits.CategoryDiscoverer", "GildedRose")]
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public abstract class CategoryAttribute : Attribute, ITraitAttribute
    {
        public abstract string Value { get; }
    }
}