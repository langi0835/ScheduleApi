using ScheduleApi.Business.Repositories.Interfaces;
using ScheduleApi.Models;

namespace ScheduleApi.DataAccess.Repositories
{
  public class ScheduleInfoRepository : Repository<ScheduleInfo>, IScheduleInfoRepository
  {
    public ScheduleInfoRepository(ScheduleDbContext context) : base(context)
    {

    }
  }
}