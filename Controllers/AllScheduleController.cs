using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ScheduleApi.Business.Repositories.Interfaces;
using ScheduleApi.Business.Services;
using ScheduleApi.Business.Services.interfaces;
using ScheduleApi.Common;
using ScheduleApi.DTOs;
using ScheduleApi.Models;

namespace ScheduleApi.Controllers
{
  public class AllScheduleController : BaseController
  {

    private readonly IAllScheduleRepository _repo;
    public AllScheduleController(IAllScheduleRepository repo)
    {
      _repo = repo;
    }

    [HttpGet]
    public IPagination<AllScheduleItem> GetAllSchedulePagination([FromQuery] AllScheduleConditions conditions)
    {
      return _repo.GetAllSchedulePagination(conditions);
    }


    [HttpPost]
    public IPagination<AllScheduleItem> PostAllScheduleItem([FromBody] AllScheduleConditions conditions)
    {
      return _repo.GetAllSchedulePagination(conditions);
    }

  }
}
