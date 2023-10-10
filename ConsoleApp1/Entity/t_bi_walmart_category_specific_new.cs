using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace t_bi_walmart_publish_task_management
{
    ///<summary>
    ///Walmart类目属性
    ///</summary>
    [SugarTable("t_bi_walmart_category_specific_new")]
    public partial class t_bi_walmart_category_specific_new
    {
           public t_bi_walmart_category_specific_new(){


           }
           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public long Id {get;set;}

           /// <summary>
           /// Desc:类目名称
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string CategoryName {get;set;}

           /// <summary>
           /// Desc:属性名称
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string SpecificName {get;set;}

           /// <summary>
           /// Desc:API属性名称
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string FeedName {get;set;}

           /// <summary>
           /// Desc:数据类型
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string DataType {get;set;}

           /// <summary>
           /// Desc:数据格式
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Format {get;set;}

           /// <summary>
           /// Desc:文本最小长度
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? MinLength {get;set;}

           /// <summary>
           /// Desc:文本最大长度
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? MaxLength {get;set;}

           /// <summary>
           /// Desc:集合最小个数
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? MinItems {get;set;}

           /// <summary>
           /// Desc:集合类型
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string MinItemType {get;set;}

           /// <summary>
           /// Desc:前端展示类型[文本框text 单选single 多选multiple 带单位unit]
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ShowType {get;set;}

           /// <summary>
           /// Desc:推荐下拉值
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Enums {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? MiniMum {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? MaxiNum {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public byte? ExclusiveMaximum {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? MultipleOf {get;set;}

           /// <summary>
           /// Desc:使用限制[Optional  Recommended  Required]
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string UsageConstraint {get;set;}

           /// <summary>
           /// Desc:描述信息
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Description {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public long? ParentId {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ParentSpecificName {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           public DateTime CreateTime {get;set;}

           /// <summary>
           /// Desc:分组[Orderable Visible]
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Group {get;set;}

    }
}
