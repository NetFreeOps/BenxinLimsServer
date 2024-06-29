using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenXinLims.Core.Entry
{
    public class PageEntityBase
    {
        /// <summary>
        /// 当前页码
        /// </summary>
        public int PageIndex { get; set; } = 1;
        /// <summary>
        /// 每页数据数
        /// </summary>
        public int PageSize { get; set; } = 10;
        /// <summary>
        /// 数据总数
        /// </summary>
        public int total { get; set; } = 10;
    }

    public class PageOutEntity : PageEntityBase
    {
        public dynamic pageData { get; set; }
    }
}
