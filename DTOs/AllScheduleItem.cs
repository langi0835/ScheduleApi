using System;

namespace ScheduleApi.DTOs
{
  public class AllScheduleItem
  {
    public string INFO_NAME { get; set; }
    public string JOB_SCHEDULE_ID { get; set; }
    public string TASKSET_NAME { get; set; }
    public string ACTION { get; set; }
    public string DESCRIPTION { get; set; }
    public DateTime? SELECTEDDATE { get; set; }
    public string SELECTEDTIME { get; set; }
    public int ISENABLED { get; set; }
  }
}