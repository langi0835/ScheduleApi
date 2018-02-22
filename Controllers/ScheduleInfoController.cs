using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ScheduleApi.Business.Repositories.Interfaces;
using ScheduleApi.Business.Services;
using ScheduleApi.Business.Services.interfaces;
using ScheduleApi.Models;

namespace ScheduleApi.Controllers
{
  [Route("api/[controller]")]
  public class ScheduleInfoController : Controller
  {
    private readonly IScheduleInfoService _srv;
    private readonly IScheduleInfoRepository _repo;
    public ScheduleInfoController(IScheduleInfoRepository repo)
    {
      _srv = new ScheduleInfoService(repo);
      _repo = repo;
    }

    [HttpGet]
    public IEnumerable<ScheduleInfo> GetAll()
    {
      return _srv.GetAll();
    }

    [HttpGet("{id}", Name = "GetScheduleInfo")]
    public IActionResult GetById(int id)
    {
      var resultData = _srv.GetById(id);
      if (resultData == null)
        return NotFound();
      else
        return resultData;
    }

    [HttpPost]
    public IActionResult Insert([FromBody] ScheduleInfo schedule)
    {
      if (schedule == null)
        return BadRequest();

      _repo.Insert(schedule);

      return CreatedAtRoute("GetScheduleInfo", new { id = schedule.Id }, schedule);
    }

    [HttpPut]
    public IActionResult Update([FromBody]ScheduleInfo schedule)
    {
      if (schedule == null)
        return BadRequest();

      _repo.Update(schedule);

      return new NoContentResult();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      var orgSchedule = _repo.Get(x => x.Id == id);
      if (orgSchedule == null)
        return NotFound();

      _repo.Delete(orgSchedule);

      return new NoContentResult();
    }
  }
}
