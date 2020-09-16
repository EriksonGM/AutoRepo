using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AutoRepo.UI.Helpers
{
    public static class PagingExtension
    {
        public static async Task<DataCollection<T>> ToDataCollectionAsync<T>(
            this IQueryable<T> query,
            int page,
            int take)
        {
            var originalPages = page;

            page--;

            if (page > 0)
                page = page * take;

            var result = new DataCollection<T>
            {
                Items = await query.Skip(page).Take(take).ToListAsync(),
                Total = await query.CountAsync(),
                Page = originalPages
            };

            if (result.Total > 0)
            {
                result.Pages = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(result.Total) / take));
            }

            return result;
        }

        public static DataCollection<T> ToDataCollection<T>(
            this IQueryable<T> query,
            int page,
            int take)
        {
            var originalPages = page;

            page--;

            if (page > 0)
                page = page * take;

            var result = new DataCollection<T>
            {
                Items = query.Skip(page).Take(take).ToList(),
                Total = query.Count(),
                Page = originalPages
            };

            if (result.Total > 0)
            {
                result.Pages = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(result.Total) / take));
            }

            return result;
        }
    }
    public class DataCollection<T>
    {
        public bool HasItems => Items != null && Items.Any();
        public IEnumerable<T> Items { get; set; }
        public int Total { get; set; }
        public int Page { get; set; }
        public int Pages { get; set; }
    }

}
