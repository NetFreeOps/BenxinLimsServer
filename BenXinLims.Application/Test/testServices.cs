using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenXinLims.Application.Test
{
    public class testServices:IDynamicApiController,ITransient
    {
        // 建立新检测
        public Task<string> createTest(string analysisName)
        {
            return Task.FromResult("OK");
        }
        // 删除检测
        public Task<string> deleteTest(string analysisName)
        {
            return Task.FromResult("OK");
        }
        // 获取检测列表
        public Task<string> getTestList()
        {
            return Task.FromResult("OK");
        }
        // 更新检测信息
        public Task<string> updateTest(string analysisName)
        {
            return Task.FromResult("OK");
        }
        // 为检测添加分项
        public Task<string> addItemToTest(string analysisName)
        {
            return Task.FromResult("OK");
        }
        // 更新检测状态
        public Task<string> updateTestStatus(string analysisName)
        {
            return Task.FromResult("OK");
        }
    }
}
