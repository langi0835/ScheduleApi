using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ScheduleApi.Models;

namespace ScheduleApi.Business.Services.interfaces
{
  public interface IScheduleInfoService
  {
    IList<ScheduleInfo> GetAll();
    IActionResult GetById(int id);
  }
}