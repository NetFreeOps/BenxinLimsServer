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
        /// 查询模板条件
        /// </summary>
        /// <param name="queryDto"></param>
        /// <returns></returns>
        public async Task<List<TemplateEntry>> GetTemplateList([FromQuery] templateQueryDto queryDto)
        {

            var templates = await _dbContext.Queryable<TemplateEntry>()
                .WhereIF(!string.IsNullOrEmpty(queryDto.templateName), it => it.TemplateName.Contains(queryDto.templateName))
                .WhereIF(!string.IsNullOrEmpty(queryDto.templateType), it => it.TemplateType.Contains(queryDto.templateType))
                .ToListAsync();

            return templates;
        }

        /// <summary>
        /// 添加模板
        /// </summary>
        /// <param name="template"></param>
        /// <returns></returns>
        public async Task<int> AddTemplate(TemplateEntry template)
        {
            // 检查模板名称是否重复
            var isExist = await _dbContext.Queryable<TemplateEntry>().AnyAsync(it => it.TemplateName == template.TemplateName);
            if (isExist)
            {
                throw Oops.Oh(string.Format("模板名称{0}已存在", template.TemplateName));
            }
            var result = await _dbContext.Insertable(template).ExecuteReturnIdentityAsync();
            return result;
        }

        /// <summary>
        /// 删除模板
        /// </summary>
        /// <param name="templateName"></param>
        /// <returns></returns>
        public async Task<int> DeleteTemplate(string templateName)
        {
            var result = await _dbContext.Deleteable<TemplateEntry>().Where(it => it.TemplateName == templateName).ExecuteCommandAsync();
            // 删除模板名称对应的分项
            await _dbContext.Deleteable<TemplateItemEntry>().Where(it => it.TemplateName == templateName).ExecuteCommandAsync();
            return result;
        }

        /// <summary>
        /// 更新模板
        /// </summary>
        /// <param name="template"></param>
        /// <returns></returns>
        public async Task<int> UpdateTemplate(TemplateEntry template)
        {
            // 检查模板名称是否重复
            var isExist = await _dbContext.Queryable<TemplateEntry>().AnyAsync(it => it.TemplateName == template.TemplateName && it.Id != template.Id);
            if (isExist)
            {
                throw Oops.Oh(string.Format("模板名称{0}已存在", template.TemplateName));
            }
            var result = await _dbContext.Updateable(template).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
            // 同步更新模板分项中的模板名称
            var items = await _dbContext.Queryable<TemplateItemEntry>()
                .Where(it => it.TemplateName == template.TemplateName)
                .ToListAsync();
            foreach (var item in items)
            {
                item.TemplateName = template.TemplateName;
                await _dbContext.Updateable(item).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
            }
            return result;
        }
        /// <summary>
        /// 获取模板分项值
        /// </summary>
        /// <param name="templateName"></param>
        /// <returns></returns>

        public async Task<List<TemplateItemEntry>> GetTemplateItemList([FromQuery] string templateName)
        {
            var items = await _dbContext.Queryable<TemplateItemEntry>()
                .Where(it => it.TemplateName == templateName)
                .ToListAsync();
            return items;
        }

        /// <summary>
        /// 插入模板分析
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public async Task<string> UpdateTemplateItemList(List<TemplateItemEntry> items)
        {
           
            await _dbContext.Insertable(items).ExecuteCommandAsync();
            return "success";
        }
        /// <summary>
        /// 更新模板分析
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<string> UpdateTemplateItem(TemplateItemEntry item)
        {
            var result = await _dbContext.Updateable(item).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
            return "success";
        }

        /// <summary>
        /// 获取SQL查询结果
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public async Task<List<dynamic>> GetSqlResult(string sql)
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

