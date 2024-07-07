using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenXinLims.Core.Entry
{
    /// <summary>
    /// 系统内置函数调用实体类
    /// </summary>
    public class systemSubEntry
    {
        List<subParams> subParams { get; set;}

        List<subResult> subResult { get; set; }
    }

    public class subParams
    {
        public string name { get; set; }
        public string value { get; set; }
    }
    public class subResult
    {
        public string name { get; set; }
        public string value { get; set; }
    }
}
