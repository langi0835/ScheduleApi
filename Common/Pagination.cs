using System.Collections.Generic;

namespace ScheduleApi.Common
{
  public class Pagination<T> : IPagination<T>
  {
    public int Page { get; set; }
    public int PageSize { get; set; }
    public int MaxPage { get; set; }

    public IEnumerable<T> Items { get; set; }
  }
}