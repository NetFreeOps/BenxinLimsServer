using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenXinLims.Core.Entry
{
    /// <summary>
    /// 登录实体类
    /// </summary>
    public class authEntry
    {
        public string userId { get; set; }

        public string userName { get; set; }

        public string userGroup { get; set; }   

        public string dataId { get; set; }

        public string token { get; set; }

        public string refreshToken { get; set; }
    }
}
