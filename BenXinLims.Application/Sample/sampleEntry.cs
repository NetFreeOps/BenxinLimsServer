using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenXinLims.Application.Sample
{
    /// <summary>
    /// 样品实体类
    ///</summary>
    [SugarTable("sample")]
    public class SampleEntry
    {
        /// <summary>
        /// 样品编号-主键 
        ///</summary>
        [SugarColumn(ColumnName = "sample_number", IsPrimaryKey = true)]
        public int SampleNumber { get; set; }
        /// <summary>
        /// 组合后显示值 
        ///</summary>
        [SugarColumn(ColumnName = "text_id")]
        public string TextId { get; set; }
        /// <summary>
        /// 状态（U,I,P,C,A,E,X,R) 
        ///</summary>
        [SugarColumn(ColumnName = "status")]
        public string Status { get; set; }
        /// <summary>
        /// 原状态 
        ///</summary>
        [SugarColumn(ColumnName = "old_status")]
        public string OldStatus { get; set; }
        /// <summary>
        /// 父样品样品号,默认为0 
        ///</summary>
        [SugarColumn(ColumnName = "parent_number")]
        public int? ParentNumber { get; set; }
        /// <summary>
        /// 合格 
        ///</summary>
        [SugarColumn(ColumnName = "in_spec")]
        public string InSpec { get; set; }
        /// <summary>
        /// 内控 
        ///</summary>
        [SugarColumn(ColumnName = "in_control")]
        public string InControl { get; set; }
        /// <summary>
        /// 样品分类 
        ///</summary>
        [SugarColumn(ColumnName = "sample_type")]
        public string SampleType { get; set; }
        /// <summary>
        /// 样品数量 
        ///</summary>
        [SugarColumn(ColumnName = "sample_volume")]
        public string SampleVolume { get; set; }
        /// <summary>
        /// 样品单位 
        ///</summary>
        [SugarColumn(ColumnName = "sample_unit")]
        public string SampleUnit { get; set; }
        /// <summary>
        /// 登记时间 
        ///</summary>
        [SugarColumn(ColumnName = "login_date")]
        public DateTime? LoginDate { get; set; }
        /// <summary>
        /// 登记人 
        ///</summary>
        [SugarColumn(ColumnName = "login_by")]
        public string LoginBy { get; set; }
        /// <summary>
        /// 样品时间（可以是取样时间） 
        ///</summary>
        [SugarColumn(ColumnName = "sampled_date")]
        public DateTime? SampledDate { get; set; }
        /// <summary>
        /// 接收时间 
        ///</summary>
        [SugarColumn(ColumnName = "recived_date")]
        public DateTime? RecivedDate { get; set; }
        /// <summary>
        /// 接收人 
        ///</summary>
        [SugarColumn(ColumnName = "recived_by")]
        public string RecivedBy { get; set; }
        /// <summary>
        /// 开始时间，样品从I变为P的时间 
        ///</summary>
        [SugarColumn(ColumnName = "start_date")]
        public DateTime? StartDate { get; set; }
        /// <summary>
        /// 完成时间，样品由P变为C的时间 
        ///</summary>
        [SugarColumn(ColumnName = "end_date")]
        public DateTime? EndDate { get; set; }
        /// <summary>
        /// 审核时间 
        ///</summary>
        [SugarColumn(ColumnName = "reviewed_date")]
        public DateTime? ReviewedDate { get; set; }
        /// <summary>
        /// 审核人 
        ///</summary>
        [SugarColumn(ColumnName = "reviewed_by")]
        public string ReviewedBy { get; set; }
        /// <summary>
        /// 发布时间 
        ///</summary>
        [SugarColumn(ColumnName = "release_date")]
        public DateTime? ReleaseDate { get; set; }
        /// <summary>
        /// 发布人 
        ///</summary>
        [SugarColumn(ColumnName = "release_by")]
        public string ReleaseBy { get; set; }
        /// <summary>
        /// 批次号 
        ///</summary>
        [SugarColumn(ColumnName = "batch_id")]
        public string BatchId { get; set; }
        /// <summary>
        /// ERP系统ID号 
        ///</summary>
        [SugarColumn(ColumnName = "erp_id")]
        public string ErpId { get; set; }
        /// <summary>
        /// 流水号 
        ///</summary>
        [SugarColumn(ColumnName = "order_id")]
        public string OrderId { get; set; }
        /// <summary>
        /// 样品状态 
        ///</summary>
        [SugarColumn(ColumnName = "sample_status")]
        public string SampleStatus { get; set; }
        /// <summary>
        /// 样品登记模板 
        ///</summary>
        [SugarColumn(ColumnName = "sample_template")]
        public string SampleTemplate { get; set; }
        /// <summary>
        /// 样品名称 
        ///</summary>
        [SugarColumn(ColumnName = "sample_name")]
        public string SampleName { get; set; }
        /// <summary>
        /// 产品名称 
        ///</summary>
        [SugarColumn(ColumnName = "product_name")]
        public string ProductName { get; set; }
        /// <summary>
        /// 关联文件ID 
        ///</summary>
        [SugarColumn(ColumnName = "file_link")]
        public string FileLink { get; set; }
        /// <summary>
        /// 装置名 
        ///</summary>
        [SugarColumn(ColumnName = "process_unit")]
        public string ProcessUnit { get; set; }
        /// <summary>
        /// 登记备注 
        ///</summary>
        [SugarColumn(ColumnName = "login_remark")]
        public string LoginRemark { get; set; }
        /// <summary>
        /// 发布备注 
        ///</summary>
        [SugarColumn(ColumnName = "release_commit")]
        public string ReleaseCommit { get; set; }
    }
}
