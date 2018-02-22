
using System.Data;
using Microsoft.EntityFrameworkCore;
using ScheduleApi.Business.Repositories.Interfaces;
using Dapper;

namespace ScheduleApi.DataAccess.Repositories
{
  public class Repository : IRepository
  {
    protected readonly ScheduleDbContext _db;
    public Repository(ScheduleDbContext db)
    {
      _db = db;
    }

    protected IDbConnection GetConnection()
    {
      return _db.Database.GetDbConnection();
    }

    protected int Execute(string sql, object param = null, IDbTransaction transaction = null)
    {
      var conn = GetConnection();
      return conn.Execute(sql, param, transaction);
    }

    protected int SaveChanges()
    {
      return _db.SaveChanges();
    }

  }
}
