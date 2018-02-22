using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ScheduleApi.Business.Repositories.Interfaces;
using ScheduleApi.Business.Services.interfaces;
using ScheduleApi.Models;

namespace ScheduleApi.Business.Services
{
  public class ScheduleInfoService : IScheduleInfoService
  {
    private readonly IScheduleInfoRepository _repo;
    public ScheduleInfoService(IScheduleInfoRepository repo)
    {
      _repo = repo;
    }
    public IList<ScheduleInfo> GetAll()
    {
      return _repo.GetAll().ToList();
    }

    public IActionResult GetById(int id)
    {
      var scheduleData = _repo.Get(x => x.Id == id);
      return new ObjectResult(scheduleData);
    }
  }
}