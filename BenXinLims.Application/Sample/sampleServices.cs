namespace BenXinLims.Application
{
    /// <summary>
    /// 样品服务
    /// </summary>
    public class sampleServices: IDynamicApiController
    {
        /// <summary>
        /// 登记样品
        /// </summary>
        /// <param name="sample_number"></param>
        /// <returns></returns>
        public Task<string> loginSample(string sample_number)
        {
            return Task.FromResult("loginSample");
        }

        // 接收样品
        public Task<string> receiveSample(string sample_number)
        {
            return Task.FromResult("receiveSample");
        }
        // 样品审核
        public Task<string> auditSample(string sample_number,string auditGrade)
        {
            return Task.FromResult("auditSample");
        }
        // 驳回样品
        public Task<string> rejectSample(string sample_number)
        {
            return Task.FromResult("rejectSample");
        }
        // 重新激活样品
        public Task<string> activeSample(string sample_number)
        {
            return Task.FromResult("activeSample");
        }
        // 样品分包
        public Task<string> packageSample(string sample_number)
        {
            return Task.FromResult("packageSample");
        }
        // 创建留样
        public Task<string> createRetainSample(string sample_number)
        {
            return Task.FromResult("createRetainSample");
        }
        // 更改样品信息，传入字段：要更改的字段，要更改的值--限制某些字段不能更改
        public Task<string> updateSample(string sample_number)
        {
            return Task.FromResult("updateSample");
        }
        // 更改样品状态
        public Task<string> updateSampleStatus(string sample_number)
        {
            return Task.FromResult("updateSampleStatus");
        }


    }
}
