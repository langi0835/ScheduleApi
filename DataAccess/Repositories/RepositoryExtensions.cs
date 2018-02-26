using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ScheduleApi.Business.Repositories.Interfaces;
using ScheduleApi.Common;

namespace ScheduleApi.DataAccess.Repositories
{

  public static class RepositoryExtensions
  {
    const int DefaultPage = 1;
    const int DefaultPageSize = 10;

    private static IPagination<TEntity> CreatePagination<TEntity>(IPaginationConditions paginationConditions, int count, IEnumerable<TEntity> items)
      where TEntity : class
    {
      var page = GetPageValue(paginationConditions);
      var pageSize = GetPageSizeValue(paginationConditions);
      var result = new Pagination<TEntity>
      {
        Page = page,
        PageSize = pageSize,
        MaxPage = (count / pageSize) + ((count % pageSize == 0) ? 0 : 1),
        Items = items
      };
      return result;
    }

    private static int CalcSkip(IPaginationConditions paginationConditions)
    {
      var page = GetPageValue(paginationConditions);
      var pageSize = GetPageSizeValue(paginationConditions);
      return pageSize * (page - 1);
    }

    private static int GetPageValue(IPaginationConditions paginationConditions)
    {
      var page = paginationConditions.Page.HasValue ? paginationConditions.Page.Value : DefaultPage;
      return page;
    }

    private static int GetPageSizeValue(IPaginationConditions paginationConditions)
    {
      var pageSize = paginationConditions.PageSize.HasValue ? paginationConditions.PageSize.Value : DefaultPageSize;
      return pageSize;
    }

    public static IPagination<TEntity> GetPagination<TEntity>(this Repository repo,
                                  IPaginationConditions paginationConditions,
                                  string sql,
                                  Dictionary<string, object> param = null)
                                  where TEntity : class
    {
      var allItems = repo.Query<TEntity>(sql, param);
      var items = repo.PaginationQuery<TEntity>(allItems, CalcSkip(paginationConditions), GetPageSizeValue(paginationConditions));
      var count = allItems.Count();

      var result = CreatePagination(paginationConditions, count, items);
      return result;
    }

  }
}