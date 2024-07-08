using BenXinLims.Core.Entry;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenXinLims.Core.Services
{
    /// <summary>
    /// 动态接口服务
    /// </summary>
    public class sysDynamicSubService : IDynamicApiController
    {
        private readonly IDynamicApiRuntimeChangeProvider _changeProvider;

        public sysDynamicSubService(IDynamicApiRuntimeChangeProvider changeProvider)
        {
            _changeProvider = changeProvider;
        }
        /// <summary>
        /// 动态调用系统函数
        /// </summary>
        /// <param name="callSystemSub"></param>
        /// <param name="subName">函数名称</param>
        /// <returns></returns>
        public dynamic CallSystemSub([FromBody] systemSubEntry callSystemSub, [FromQuery] string subName)
        {
            switch (subName)
            {
                case "":

                    break;
                default:
                    break;
            }
            return "";
        }
        /// <summary>
        /// 保存动态代码
        /// </summary>
        /// <param name="csharpCode"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<int> SaveDynamicCode([FromBody] string csharpCode, [FromQuery] calcEntryDto dto)
        {

            var db = DbContext.Instance;
            if (dto.type == "analysis")
            {
                AnalysisCalc analysisCalc = new AnalysisCalc();
                analysisCalc.Id = dto.Id;
                analysisCalc.AnalysisId = dto.AnalysisId;
                analysisCalc.AnalysisItemId = dto.AnalysisItemId;
                analysisCalc.SourceCode = csharpCode;
                // 检查analysisitemid是否存在
                var analysisItem = db.Queryable<AnalysisCalc>().Where(x => x.AnalysisItemId == dto.AnalysisItemId).First();
                if (analysisItem == null)
                {
                 return   await  db.Insertable(analysisCalc).ExecuteCommandAsync();//插入
                }
                else
                {
                 return await  db.Updateable(analysisCalc).ExecuteCommandAsync();//更新
                }
            }
            if (dto.type == "common")
            {
                CommonCalc commonCalc = new CommonCalc();
                commonCalc.Id = dto.Id;
                commonCalc.Name = dto.Name;
                commonCalc.SourceCode = csharpCode;
                // 根据name检查是否存在

                var commonItem = db.Queryable<CommonCalc>().Where(x => x.Name == dto.Name).First();
                if (commonItem == null)
                {
                 return   await db.Insertable(commonCalc).ExecuteCommandAsync();//插入
                }
                else
                {
                 return await  db.Updateable(commonCalc).ExecuteCommandAsync();//更新
                }
            }
            return -1;
        }
        /// <summary>
        /// 获取动态代码
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public string GetDynamicCode([FromQuery] calcEntryDto dto)
        {
            string result = default;
            var db = DbContext.Instance;
            if (dto.type == "analysis")
            {
                var analysisItem = db.Queryable<AnalysisCalc>().Where(x => x.AnalysisItemId == dto.AnalysisItemId && x.AnalysisItemId == dto.AnalysisItemId).First();
                if (analysisItem != null)
                {
                    result = analysisItem.SourceCode;
                }
            }
            if (dto.type == "common")
            {
                var commonItem = db.Queryable<CommonCalc>().Where(x => x.Name == dto.Name).First();
                if (commonItem != null)
                {
                    result = commonItem.SourceCode;
                }
            }
            return result;
        }

        /// <summary>
        /// 动态添加 WebAPI/Controller
        /// </summary>
        /// <param name="csharpCode"></param>
        /// <param name="dto">程序名称</param>
        /// <returns></returns>

        public string Compile([FromBody] string csharpCode, [FromQuery] calcEntryDto dto)
        {
            string assemblyName = default;

            // 拼接代码

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("using Furion.DynamicApiController;");
            sb.AppendLine("namespace BenXinLims.Core.Services");
            sb.Append("{");
            sb.AppendLine("public class userSub : IDynamicApiController");
            sb.AppendLine("{");
            sb.AppendLine(" /// <summary>");
            sb.AppendLine("/// <summary>");
            if (dto.type == "common")
            {
                sb.AppendLine("///" + dto.Name);
            }
            if (dto.type == "analysis")
            {
                sb.AppendLine("///" + dto.AnalysisId + "-" + dto.AnalysisItemId);
            }
            sb.AppendLine("/// </summary>");
            sb.AppendLine("/// <returns></returns>");
            sb.AppendLine(csharpCode);
            sb.AppendLine("}}");



            try
            {
                // Ensure sb is not modified during compilation
                lock (sb)
                {
                    // Compile C# Code
                    var dynamicAssembly = App.CompileCSharpClassCode(sb.ToString(), assemblyName);

                    // Add Assembly to Change Provider
                    _changeProvider.AddAssembliesWithNotifyChanges(dynamicAssembly);

                    var db = DbContext.Instance;
                    if (dto.type == "analysis")
                    {
                        AnalysisCalc analysisCalc = new AnalysisCalc();
                        analysisCalc.Id = dto.Id;
                        analysisCalc.AnalysisId = dto.AnalysisId;
                        analysisCalc.AnalysisItemId = dto.AnalysisItemId;
                        analysisCalc.SourceCode = csharpCode;
                        // 检查analysisitemid是否存在
                        var analysisItem = db.Queryable<AnalysisCalc>().Where(x => x.AnalysisItemId == dto.AnalysisItemId).First();
                        if (analysisItem == null)
                        {
                            db.Insertable(analysisCalc).ExecuteCommandAsync();//插入
                        }
                        else
                        {
                            db.Updateable(analysisCalc).ExecuteCommandAsync();//更新
                        }
                    }
                    if (dto.type == "common")
                    {
                        CommonCalc commonCalc = new CommonCalc();
                        commonCalc.Id = dto.Id;
                        commonCalc.Name = dto.Name;
                        commonCalc.SourceCode = csharpCode;
                        // 根据name检查是否存在

                        var commonItem = db.Queryable<CommonCalc>().Where(x => x.Name == dto.Name).First();
                        if (commonItem == null)
                        {
                            db.Insertable(commonCalc).ExecuteCommandAsync();//插入
                        }
                        else
                        {
                            db.Updateable(commonCalc).ExecuteCommandAsync();//更新
                        }
                    }

                    // 返回动态程序集名称
                    return dynamicAssembly.GetName().Name;
                }
            }
            catch (Exception ex)
            {
                // Handle compilation errors
                Console.WriteLine($"Failed to compile code: {ex.Message}");
                // Log the exception or take other appropriate action
                return $"Failed to compile code: {ex.Message}";
            }


        }

        /// <summary>
        /// 移除动态程序集 WebAPI/Controller
        /// </summary>
        public void Remove(string assemblyName)
        {
            _changeProvider.RemoveAssembliesWithNotifyChanges(assemblyName);
        }

    }
}
