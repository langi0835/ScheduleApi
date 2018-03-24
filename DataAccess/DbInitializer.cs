using ScheduleApi.Models;
using System;
using System.Linq;

namespace ScheduleApi.DataAccess
{
  public static class DbInitializer
  {
    public static void Initialize(ScheduleDbContext context)
    {
      //if (env.EnvironmentName == "Development")      
      context.Database.EnsureDeleted();
      context.Database.EnsureCreated();

      // Look for any data
      if (context.ScheduleInfos.Any())
      {
        return;   // DB has been seeded
      }

      var scheduleInfos = new ScheduleInfo[]
      {
        new ScheduleInfo{InfoName="info1",Schema="SMART901"}
      };

      foreach (ScheduleInfo s in scheduleInfos)
      {
        context.ScheduleInfos.Add(s);
      }
      context.SaveChanges();

    }
  }
}