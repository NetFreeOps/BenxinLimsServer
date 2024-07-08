using BenXinLims.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenXinLims.Application.Analysis
{
    /// <summary>
    /// 分析服务
    /// </summary>
    public class AnalysisServices : IDynamicApiController, ITransient
    {
        /// <summary>
        /// 建立新分析
        /// </summary>
        /// <param name="analysisEntry"></param>
        /// <returns></returns>
        public async Task<int> createAnalysis(AnalysisEntry analysisEntry)
        {
            var db = DbContext.Instance;
            int res = await db.Insertable(analysisEntry).ExecuteCommandAsync();
            return res;
        }
        /// <summary>
        /// 删除分析
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> deleteAnalysis(int id)
        {
            var db = DbContext.Instance;
            //int ressub = await db.Deleteable<AnalysisEntry>().Where(.ExecuteCommandAsync();
            int res = await db.Deleteable<AnalysisEntry>().Where(it => it.Id == id).ExecuteCommandAsync();
            return res;
        }
        /// <summary>
        /// 获取所有分析列表
        /// </summary>
        /// <returns></returns>
        public async Task<List<AnalysisEntry>> getAnalysisList()
        {
            var db = DbContext.Instance;
            var list = await db.Queryable<AnalysisEntry>().ToListAsync();
            return list;
        }
        /// <summary>
        /// 更新分析
        /// </summary>
        /// <param name="analysisEntry"></param>
        /// <returns></returns>
        public async Task<int> updateAnalysis(AnalysisEntry analysisEntry)
        {
            var db = DbContext.Instance;

            int res = await db.Updateable(analysisEntry).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
            return res;
        }
        /// <summary>
        /// 为分析增加分项
        /// </summary>
        /// <param name="analysisItem"></param>
        /// <returns></returns>
        public async Task<int> addItemToAnalysis(AnalysisItemEntry analysisItem)
        {
            var db = DbContext.Instance;
            // 检查分项是否存在
            var item = await db.Queryable<AnalysisItemEntry>().Where(it => it.AnalysisName == analysisItem.AnalysisName && it.Name == analysisItem.Name).FirstAsync();
            if (item != null)
            {
                return -1;
            }
            int res = await db.Insertable(analysisItem).ExecuteCommandAsync();
            return res;
        }
        /// <summary>
        /// 根据ID删除分析的分项
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<int> deleteItemFromAnalysis(int id)
        {
            var db = DbContext.Instance;
            return db.Deleteable<AnalysisItemEntry>().Where(it => it.Id == id).ExecuteCommandAsync();
        }
        /// <summary>
        /// 根据分析名称获取分析的分项列表
        /// </summary>
        /// <param name="analysisName"></param>
        /// <returns></returns>
        public async Task<List<AnalysisItemEntry>> getItemListFromAnalysis(string analysisName)
        {
            var db = DbContext.Instance;
            var list = await db.Queryable<AnalysisItemEntry>()
                .Where(it => it.AnalysisName == analysisName)
                .ToListAsync();
            return list;
            // return Task.FromResult("OK");
        }
        /// <summary>
        /// 更新分析的分项信息
        /// </summary>
        /// <param name="analysisItem"></param>
        /// <returns></returns>
        public async Task<int> updateItemFromAnalysis(AnalysisItemEntry analysisItem)
        {
            var db = DbContext.Instance;
            // 检查分项是否存在
            var item = await db.Queryable<AnalysisItemEntry>().Where(it => it.AnalysisName == analysisItem.AnalysisName && it.Name == analysisItem.Name).FirstAsync();
            if (item == null)
            {
                return -1;
            }
            return await db.Updateable(analysisItem).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
        }
        // 为分析分配人员
        public Task<string> addUserToAnalysis(string analysis)
        {
            return Task.FromResult("OK");
        }
        // 为分析删除人员
        public Task<string> deleteUserFromAnalysis(string analysis)
        {
            return Task.FromResult("OK");
        }
        // 获取分析的人员列表
        public Task<string> getUserListFromAnalysis(string analysis)
        {
            return Task.FromResult("OK");
        }
        // 为分析添加设备
        public Task<string> addInsToAnalysis(string analysis)
        {
            return Task.FromResult("OK");
        }
        // 为分析删除设备
        public Task<string> deleteInsFromAnalysis(string analysis)
        {
            return Task.FromResult("OK");
        }

    }
}
