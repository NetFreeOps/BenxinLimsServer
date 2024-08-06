using BenXinLims.Core.Entry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenXinLims.Application.Template
{
    /// <summary>
    /// 模板实体类
    ///</summary>
    [SugarTable("template")]
    public class TemplateEntry:dbEntryBase
    {
        /// <summary>
        /// 主键 
        ///</summary>
        [SugarColumn(ColumnName = "id", IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }
        /// <summary>
        /// 模板名称，唯一 
        ///</summary>
        [SugarColumn(ColumnName = "template_name")]
        public string TemplateName { get; set; }
        /// <summary>
        /// 模板类型 
        ///</summary>
        [SugarColumn(ColumnName = "template_type")]
        public string TemplateType { get; set; }
        /// <summary>
        /// 描述信息 
        ///</summary>
        [SugarColumn(ColumnName = "description")]
        public string Description { get; set; }
        
    }

    /// <summary>
    /// 模板分项实体类
    ///</summary>
    [SugarTable("template_item")]
    public class TemplateItemEntry:dbEntryBase
    {
        /// <summary>
        /// 主键 
        ///</summary>
        [SugarColumn(ColumnName = "id", IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }
        /// <summary>
        /// 模板ID 
        ///</summary>
        [SugarColumn(ColumnName = "template_id")]
        public string TemplateId { get; set; }
        /// <summary>
        /// 模板名称 
        ///</summary>
        [SugarColumn(ColumnName = "template_name")]
        public string TemplateName { get; set; }
        /// <summary>
        /// 配置字段名 
        ///</summary>
        [SugarColumn(ColumnName = "template_field")]
        public string TemplateField { get; set; }
        /// <summary>
        /// 字段类型 
        ///</summary>
        [SugarColumn(ColumnName = "fiele_type")]
        public string FieleType { get; set; }
        /// <summary>
        /// 默认值 
        ///</summary>
        [SugarColumn(ColumnName = "default_value")]
        public string DefaultValue { get; set; }
        /// <summary>
        /// 公式型代码 
        ///</summary>
        [SugarColumn(ColumnName = "source_code")]
        public string SourceCode { get; set; }
        /// <summary>
        /// 列表型的列表名称 
        ///</summary>
        [SugarColumn(ColumnName = "list_name")]
        public string ListName { get; set; }
        /// <summary>
        /// 列表型取值字段 
        ///</summary>
        [SugarColumn(ColumnName = "list_field")]
        public string ListField { get; set; }
        /// <summary>
        /// 状态 
        ///</summary>
        [SugarColumn(ColumnName = "status")]
        public string Status { get; set; }
       
    }
    /// <summary>
    /// 数据库表结构
    /// </summary>
    public class dbField
    {
        public string FieldName { get; set; }
        public string FieldType { get; set; }
        public string FieldLength { get; set; }
        public string FieldDecimal { get; set; }
        public string FieldDefault { get; set; }
        public string FieldNull { get; set; }
        public string FieldComment { get; set; }
    }
   /// <summary>
   /// 模板查询dto
   /// </summary>
    public class templateQueryDto
    {
        public string templateName { get; set; }
        public string templateType { get; set; }
    }
}
