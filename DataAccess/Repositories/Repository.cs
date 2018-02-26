
using System.Data;
using Microsoft.EntityFrameworkCore;
using ScheduleApi.Business.Repositories.Interfaces;
using Dapper;
using System.Collections.Generic;
using System.Linq;

namespace ScheduleApi.DataAccess.Repositories
{
  public class Repository : IRepository
  {
    protected readonly DbContext _db;
    public Repository(DbContext db)
    {
      _db = db;
    }

    protected IDbConnection GetConnection()
    {
      return _db.Database.GetDbConnection();
    }

    protected Dictionary<string, object> CreateParameters()
    {
      return new Dictionary<string, object>();
    }

    protected int Execute(string sql, object param = null, IDbTransaction transaction = null)
    {
      var conn = GetConnection();
      return conn.Execute(sql, param, transaction);
    }

    public IEnumerable<TEntity> Query<TEntity>(string sql, Dictionary<string, object> param = null, IDbTransaction transaction = null)
    {
      var conn = GetConnection();
      return conn.Query<TEntity>(sql, param, transaction);
    }

    public IEnumerable<TEntity> PaginationQuery<TEntity>(IEnumerable<TEntity> allItems, int skip, int take)
    {
      return allItems.Skip(skip).Take(take);
    }

    protected int SaveChanges()
    {
      return _db.SaveChanges();
    }

  }
}
