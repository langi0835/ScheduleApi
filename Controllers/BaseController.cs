using Microsoft.AspNetCore.Mvc;

namespace ScheduleApi.Controllers
{
  [Route("api/[controller]/[action]")]
  public abstract class BaseController : Controller { }
}