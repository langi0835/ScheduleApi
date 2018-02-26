using System.Collections.Generic;

namespace ScheduleApi.Common
{
  public static class SqlParamterDictionaryExtensions
  {
    /// <summary>
    /// 加入到參數裡面，並回傳SQL
    /// </summary>
    private static string Combine(this Dictionary<string, object> paramDict, string paritalSql, string paramName, object value)
    {
      paramDict.Add(paramName, value);
      return paritalSql;
    }

    /// <summary>
    /// 要更新的內容，必須要有文字才會加入到參數裡面，並回傳SQL，若沒有則會回傳空字串。
    /// </summary>
    public static string CombineNotNullOrEmpty(this Dictionary<string, object> paramDict, string paritalSql,
      string paramName, object value)
    {
      if (!string.IsNullOrEmpty(value as string) || (value != null && !(value is string)))
      {
        return Combine(paramDict, paritalSql, paramName, value);
      }

      return string.Empty;
    }
  }

}