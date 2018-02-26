using ScheduleApi.Common;
using ScheduleApi.DTOs;

namespace ScheduleApi.Business.Repositories.Interfaces
{
  public interface IAllScheduleRepository : IRepository
  {
    IPagination<AllScheduleItem> GetAllSchedulePagination(AllScheduleConditions conditions);
  }
}