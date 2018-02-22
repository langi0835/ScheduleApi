using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ScheduleApi.Business.Repositories.Interfaces;
using ScheduleApi.DataAccess;
using ScheduleApi.DataAccess.Repositories;
using ScheduleApi.Middleware;

namespace ScheduleApi
{
  public class Startup
  {
    //public Startup(IConfiguration configuration)
    public Startup(IHostingEnvironment env)
    {

      var builder = new ConfigurationBuilder()
          .SetBasePath(env.ContentRootPath)
          .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
          .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
          .AddEnvironmentVariables();

      Configuration = builder.Build();
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      var connectionString = Configuration.GetConnectionString("DefaultConnection");

      //注入DbContext(AddDbContextPool:可共用的pool)
      services.AddDbContextPool<ScheduleDbContext>(o => o.UseSqlServer(connectionString));

      //注入Repository
      services.AddTransient<IScheduleInfoRepository, ScheduleInfoRepository>();

      services.AddMvc();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, ScheduleDbContext dbContext)
    {

      loggerFactory.AddConsole(Configuration.GetSection("Logging"));
      // loggerFactory.AddDebug();

      // 存取 SPA 網頁資源
      app.UseSpaStaticFiles();

      app.UseDefaultFiles();
      app.UseStaticFiles();
      app.UseMvc();

      //建立DB
      //if (env.EnvironmentName == "Development")      
      dbContext.Database.EnsureDeleted();

      dbContext.Database.EnsureCreated();

    }

  }
}
