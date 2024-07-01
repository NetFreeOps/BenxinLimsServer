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
            int res = await db.Deleteable<AnalysisEntry>().Where(it =>it.Id == id).ExecuteCommandAsync();
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
        // 更新分析信息
        public async Task<int> updateAnalysis(AnalysisEntry analysisEntry)
        {
            var db = DbContext.Instance;

            int res = await db.Updateable(analysisEntry).ExecuteCommandAsync();
            return res;
        }
        // 为分析添加分项
        public Task<string> addItemToAnalysis(string analysisName)
        {
            return Task.FromResult("OK");
        }
        // 为分析删除分项
        public Task<string> deleteItemFromAnalysis(string analysisName)
        {
            return Task.FromResult("OK");
        }
        // 获取分析的分项列表
        public Task<string> getItemListFromAnalysis(string analysisName)
        {
            return Task.FromResult("OK");
        }
        // 更新分析的分项信息
        public Task<string> updateItemFromAnalysis(string analysisName)
        {
            return Task.FromResult("OK");
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
