﻿using GrpcClient_PI_21_01.Models;
using System.Linq.Expressions;

namespace GrpcClient_PI_21_01.Controllers
{
    public static class SorterService
    {
        public static void SortByColumn<T>(Filter<T> filter, DataGridViewColumn c)
        {
            if (c.Tag is not Expression<Func<T, object>> exp)
                throw new Exception("Column entity tags were empty");
            var currentSort = c.HeaderCell.SortGlyphDirection;
            c.HeaderCell.SortGlyphDirection =
                currentSort == SortOrder.None ? SortOrder.Ascending :
                (currentSort == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending);
            var sort = c.HeaderCell.SortGlyphDirection == SortOrder.Ascending ? SortType.Asc : SortType.Desc;
            filter.SetSort(exp, sort);
        }
    }
}
