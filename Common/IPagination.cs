using System.Collections.Generic;

namespace ScheduleApi.Common
{
  public interface IPagination<T>
  {
    int Page { get; set; }
    int PageSize { get; set; }
    int MaxPage { get; set; }

    IEnumerable<T> Items { get; set; }
  }
}