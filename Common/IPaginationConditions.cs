namespace ScheduleApi.Common
{
  public interface IPaginationConditions
  {
    int? Page { get; set; }
    int? PageSize { get; set; }
  }
}