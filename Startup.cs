using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
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
      //跨網域請求
      services.AddCors(options =>
              {
          // CorsPolicy 是自訂的 Policy 名稱
          options.AddPolicy("CorsPolicy", policy =>
          {
                    policy.WithOrigins("http://localhost:4200")//設定允許跨域的來源
                    .AllowAnyHeader()//允許任何的 Request Header
                    .AllowAnyMethod()
                    .AllowCredentials();
                  });
              });

      var connectionString = Configuration.GetConnectionString("DefaultConnection");

      //注入DbContext(AddDbContextPool:可共用的pool)
      services.AddDbContextPool<ScheduleDbContext>(o => o.UseSqlServer(connectionString));

      //注入Repository
      services.AddTransient<IScheduleInfoRepository, ScheduleInfoRepository>();
      services.AddTransient<IAllScheduleRepository, AllScheduleRepository>();

      services.AddRouting();

      services.AddMvc();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, ScheduleDbContext dbContext)
    {

      loggerFactory.AddConsole(Configuration.GetSection("Logging"));
      // loggerFactory.AddDebug();

      //跨網域請求套用
      app.UseCors("CorsPolicy");

      // 存取 SPA 網頁資源
      app.UseSpaStaticFiles();

      app.UseDefaultFiles();
      app.UseStaticFiles();
      app.UseMvc();

      //建置Route
      var defaultRouteHandler = new RouteHandler(context =>
              {
                var routeValues = context.GetRouteData().Values;
                return context.Response.WriteAsync($"Route values: {string.Join(", ", routeValues)}");
              });
      //在這個物件定義路由規則，當 Requset URL 符合規則就會執行該事件
      var routeBuilder = new RouteBuilder(app, defaultRouteHandler);
      //預設的路由規則
      //URL 第一層透過正規表示式必需是 default 或 api，並放到路由變數 first 中
      //URL 第二層可有可無，如果有的話，放到路由變數 second 中      
      routeBuilder.MapRoute(name: "default", template: "api/{controller}/{action}/{id?}");

      //透過不同的 HTTP Method，對應不同的事件
      //指定為HTTP Get,第一層必需是 api 第二,三層必需要有值，放到路由變數 controller,action 中
      // routeBuilder.MapGet("api/{controller}/{action}/{id?}", context =>
      // {
      //   var controller = context.GetRouteValue("controller");
      //   return context.Response.WriteAsync($"Get api. controller: {controller}");
      // });

      // routeBuilder.MapPost("api/{controller}/{action}", context =>
      // {
      //   var controller = context.GetRouteValue("controller");
      //   return context.Response.WriteAsync($"post api. controller: {controller}");
      // });

      var routes = routeBuilder.Build();
      app.UseRouter(routes);


      //建立DB
      //if (env.EnvironmentName == "Development")      
      dbContext.Database.EnsureDeleted();

      dbContext.Database.EnsureCreated();

    }

  }
}
