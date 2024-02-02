using System;
using System.Collections.Generic;
using Furion;
using SqlSugar;

namespace BenXinLims.Core
{
    /// <summary>
    /// 数据库上下文对象
    /// </summary>
    public static class DbContext
    {
        /// <summary>
        /// SqlSugar 数据库实例
        /// </summary>
        public static readonly SqlSugarScope Instance = new(
            // 读取 appsettings.json 中的 ConnectionConfigs 配置节点
            App.GetConfig<List<ConnectionConfig>>("ConnectionConfigs")
            , db =>
            {
                // 这里配置全局事件，比如拦截执行 SQL
                db.Ado.CommandTimeOut = 30;
                db.Aop.OnLogExecuting = (sql, pars) =>
                {
                    if (sql.StartsWith("SELECT"))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    if (sql.StartsWith("UPDATE") || sql.StartsWith("INSERT"))
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    if (sql.StartsWith("DELETE"))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    Console.WriteLine("sql:" + "\r\n\r\n" + UtilMethods.GetSqlString(db.CurrentConnectionConfig.DbType, sql, pars));
                    App.PrintToMiniProfiler("SqlSugar", "Info", UtilMethods.GetSqlString(db.CurrentConnectionConfig.DbType, sql, pars));
                };
            });
    }
}
