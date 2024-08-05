using BenXinLims.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BenXinLims.Application.Template
{
    /// <summary>
    /// 模板服务
    /// </summary>
    public class templateServices : IDynamicApiController, ITransient
    {
        // 注入数据库上下文
        private readonly ISqlSugarClient _dbContext;
        public templateServices(ISqlSugarClient dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// 获取数据库表结构
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public List<DbColumnInfo> GetDbFieldByTableName(string tableName)
        {
            var db = DbContext.Instance;
            var columms = db.DbMaintenance.GetColumnInfosByTableName(tableName);
            return columms;
        }


        /// <summary>
        /// 获取SQL查询结果
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public async Task<List<dynamic>>  GetSqlResult(string sql)
        {
            // 检查SQL语句是否符合条件
            if (IsInvalidSql(sql))
            {
                throw Oops.Oh("SQL不符合预期：sql只能包含查询、sql不能在select使用通配符*、sql只能返回单列");
            }

            // 执行查询
            var result = _dbContext.Ado.SqlQueryAsync<dynamic>(sql).Result;
            return result;
        }

        /// <summary>
        /// 检查SQL语句是否符合条件
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        private bool IsInvalidSql(string sql)
        {
            // 转换SQL为小写
            var lowerSql = sql.ToLower().Trim();

            // 正则表达式检查是否包含删除、更新、插入语句
            var forbiddenPatterns = new[]
            {
            @"^\s*delete\s+from\s+",
            @"^\s*update\s+",
            @"^\s*insert\s+into\s+"
        };

            // 正则表达式检查是否是select * 语句
            var selectStarPatterns = new[]
            {
            @"^\s*select\s+\*\s+from\s+\w+\s*;",
    @"^\s*select\s+\*\s+from\s+\w+\s*$",
    @"^\s*select\s+\*\s+from\s+\w+\s+where\s+.*"
        };

            // 检查是否是删除、更新、插入语句
            foreach (var pattern in forbiddenPatterns)
            {
                if (Regex.IsMatch(lowerSql, pattern))
                {
                    return true;
                }
            }

            // 检查是否是select * 语句
            foreach (var pattern in selectStarPatterns)
            {
                if (Regex.IsMatch(lowerSql, pattern))
                {
                    return true;
                }
            }

            // 检查是否是SELECT语句并且只返回一列
            if (IsMultipleColumnsSelect(sql))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 检查SELECT语句是否返回多列
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        private bool IsMultipleColumnsSelect(string sql)
        {
            // 去除换行符
            var sanitizedSql = sql.Replace("\n", " ").Replace("\r", " ");

            // 使用正则表达式匹配SELECT语句的列部分
            var selectColumnsPattern = @"^\s*select\s+(.*?)\s+from\s+";
            var match = Regex.Match(sanitizedSql, selectColumnsPattern, RegexOptions.IgnoreCase);
            if (match.Success)
            {
                // 提取列部分
                var columnsPart = match.Groups[1].Value;

                // 检查列部分是否包含多个列（使用逗号分隔）
                var columns = columnsPart.Split(',');
                if (columns.Length > 1)
                {
                    return true;
                }
            }

            return false;
        }
    }
}

