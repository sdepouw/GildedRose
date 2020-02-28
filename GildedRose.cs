using System.Collections.Generic;

namespace GildedRose
{
    public class GildedRose
    {
        IList<Item> Items; // Do not mutate.
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach(var item in Items)
            {
                if (item.Name != ItemNames.Sulfuras)
                {
                    item.SellIn = item.SellIn - 1;
                }

                if (item.Name != ItemNames.AgedBrie && item.Name != ItemNames.BackstagePasses)
                {
                    if (item.Quality > 0)
                    {
                        if (item.Name != ItemNames.Sulfuras)
                        {
                            item.Quality = item.Quality - 1;
                        }
                    }
                }
                else
                {
                    if (item.Quality < 50)
                    {
                        item.Quality = item.Quality + 1;

                        if (item.Name == ItemNames.BackstagePasses)
                        {
                            if (item.SellIn < 10)
                            {
                                if (item.Quality < 50)
                                {
                                    item.Quality = item.Quality + 1;
                                }
                            }

                            if (item.SellIn < 5)
                            {
                                if (item.Quality < 50)
                                {
                                    item.Quality = item.Quality + 1;
                                }
                            }
                        }
                    }
                }

                if (item.SellIn < 0)
                {
                    if (item.Name != ItemNames.AgedBrie)
                    {
                        if (item.Name != ItemNames.BackstagePasses)
                        {
                            if (item.Quality > 0)
                            {
                                if (item.Name != ItemNames.Sulfuras)
                                {
                                    item.Quality = item.Quality - 1;
                                }
                            }
                        }
                        else
                        {
                            item.Quality = 0;
                        }
                    }
                    else
                    {
                        if (item.Quality < 50)
                        {
                            item.Quality = item.Quality + 1;
                        }
                    }
                }
            }
        }
    }
}
