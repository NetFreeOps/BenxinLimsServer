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
    public class sysDynamicSubService:IDynamicApiController
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
        /// 动态添加 WebAPI/Controller
        /// </summary>
        /// <param name="csharpCode"></param>
        /// <param name="assemblyName">可自行指定程序集名称</param>
        /// <returns></returns>
       
        public string Compile([FromBody] string csharpCode, [FromQuery] string assemblyName = default)
        {
            
            // 拼接代码

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("using Furion.DynamicApiController;");
            sb.AppendLine("namespace BenXinLims.Core.Services");
            sb.Append("{");
            sb.AppendLine("public class userSub : IDynamicApiController");
            sb.AppendLine("{");
            sb.AppendLine(csharpCode);
            sb.AppendLine("}}");


            // 编译 C# 代码并返回动态程序集
            var dynamicAssembly = App.CompileCSharpClassCode(sb.ToString(), assemblyName);

            // 将程序集添加进动态 WebAPI 应用部件
            _changeProvider.AddAssembliesWithNotifyChanges(dynamicAssembly);

            // 返回动态程序集名称
            return dynamicAssembly.GetName().Name;
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
