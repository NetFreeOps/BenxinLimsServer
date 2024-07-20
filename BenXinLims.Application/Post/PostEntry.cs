using BenXinLims.Core.Entry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenXinLims.Application.Post
{
    /// <summary>
    /// 岗位表
    ///</summary>
    [SugarTable("post")]
    public class PostEntry:dbEntryBase
    {
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "id", IsPrimaryKey = true)]
        public int Id { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "post_name")]
        public string PostName { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "post_code")]
        public string PostCode { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "description")]
        public string Description { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "active")]
        public int Active { get; set; }
       

    }
}
