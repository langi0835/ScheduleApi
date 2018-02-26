using ScheduleApi.Common;

namespace ScheduleApi.DTOs
{
  public class AllScheduleConditions : PaginationConditions
  {
    public string InfoName { get; set; }
    public string ScheduleID { get; set; }
    public string TaskSetName { get; set; }
  }
}