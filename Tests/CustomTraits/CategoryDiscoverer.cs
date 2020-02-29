using System.Collections.Generic;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace GildedRose.Tests.CustomTraits
{
    public class CategoryDiscoverer : ITraitDiscoverer
    {
        private const string Key = "Category";
        public IEnumerable<KeyValuePair<string, string>> GetTraits(IAttributeInfo traitAttribute)
        {
            var attributeInfo = traitAttribute as ReflectionAttributeInfo;
            var category = attributeInfo?.Attribute as CategoryAttribute;
            var value = category?.Value ?? string.Empty;
            yield return new KeyValuePair<string, string>(Key, value);
        }
    }
}