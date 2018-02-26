namespace ScheduleApi.Common
{
  public class PaginationConditions : IPaginationConditions
  {
    public int? Page { get; set; }
    public int? PageSize { get; set; }
  }
}