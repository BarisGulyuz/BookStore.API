using BookStore.Core.Entities.Concrete.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BookStore.Bussiness.Extensions
{
    public static class IQueryableExtensions
    {
        /// <summary>
        /// Verilen Condition'a göre IQueryable objeye expression'ı ekler
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="predicate"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> query, Expression<Func<T, bool>> predicate, bool condition)
        {
            if (condition)
            {
                query = query.Where(predicate);
            }
            return query;
        }

        /// <summary>
        /// Sayflanmış formattta istenilen veriyi döndürür
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="values"></param>
        /// <param name="size"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public static async Task<PaginationDto<T>> ToPaginateAsync<T>(this IQueryable<T> values,
                                                                            int size, int page)
        {
            int totalCount = values.Count();
            int totalPages = Convert.ToInt32(Math.Ceiling(totalCount / (double)size));

            IQueryable<T> returnQuery = values.Skip(size * (page - 1))
                                              .Take(size);

            List<T> returnItems = await returnQuery.ToListAsync();

            PaginationDto<T> paginateModel = new PaginationDto<T>()
            {
                TotalCount = totalCount,
                PageNumber = page,
                Size = size,
                TotalPage = totalPages,
                Value = returnItems
            };

            return paginateModel;
        }
    }
}
