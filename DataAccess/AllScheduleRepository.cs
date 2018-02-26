using ScheduleApi.Business.Repositories.Interfaces;
using Dapper;
using ScheduleApi.Common;
using ScheduleApi.DTOs;
using ScheduleApi.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ScheduleApi.DataAccess
{
  public class AllScheduleRepository : Repository, IAllScheduleRepository
  {
    public AllScheduleRepository(ScheduleDbContext db) : base(db)
    {

    }
    public IPagination<AllScheduleItem> GetAllSchedulePagination(AllScheduleConditions conditions)
    {
      /*
      var parms = CreateParameters();
      var whereSql = parms.CombineNotNullOrEmpty(" AND A.INFO_NAME = :INFO_NAME", "INFO_NAME", conditions.InfoName);
      whereSql += parms.CombineNotNullOrEmpty(" AND B.ID LIKE '%' || :SCHEDULE_ID || '%'", "SCHEDULE_ID", conditions.ScheduleID);
      whereSql += parms.CombineNotNullOrEmpty(" AND C.TASKSET_NAME LIKE '%' || :TASKSET_NAME || '%'", "TASKSET_NAME", conditions.TaskSetName);

      var sql =
$@"SELECT A.INFO_NAME,
		 B.ID AS JOB_SCHEDULE_ID,
		 C.TASKSET_NAME AS TASKSET_NAME,
		 B.ACTION,
		 B.DESCRIPTION,
		 TRUNC (SYSDATE) AS SELECTEDDATE,
		 '' AS SELECTEDTIME,
		 (CASE WHEN B.ISENABLED = 0 OR C.ISENABLED = 0 THEN 0 ELSE 1 END) ISENABLED
  FROM JOB_SCHEDULEINFO A
		 JOIN JOB_SCHEDULE B ON A.ID = B.SCHEDULEINFOID
		 JOIN JOB_TASKSET C ON B.ID = C.SCHEDULEID
 WHERE EXISTS
			 (SELECT *
				 FROM JOB_TASK D
				WHERE C.TASKSET_NAME = D.TASKSET_NAME) 					-- 有設定任務的才顯示 
	{whereSql}
ORDER BY A.INFO_NAME, B.ID, C.TASKSET_NAME";
*/
      var parms = CreateParameters();
      var sql = @"
        SELECT 'info' INFO_NAME,'id' JOB_SCHEDULE_ID,'name' TASKSET_NAME,'action' ACTION
          ,'DESCRIPTION' DESCRIPTION,null SELECTEDDATE,'time' SELECTEDTIME,0 ISENABLED FROM ScheduleInfos ";
      var datas = this.GetPagination<AllScheduleItem>(conditions, sql, parms);
      return datas;
    }
  }
}