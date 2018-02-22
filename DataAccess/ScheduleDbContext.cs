using Microsoft.EntityFrameworkCore;
using ScheduleApi.Models;

namespace ScheduleApi.DataAccess
{
  public class ScheduleDbContext : DbContext
  {
    public ScheduleDbContext(DbContextOptions<ScheduleDbContext> options) : base(options) { }

    public DbSet<ScheduleInfo> ScheduleInfos { get; set; }
  }
}