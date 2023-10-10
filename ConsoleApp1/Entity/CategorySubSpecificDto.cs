using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class CategorySpecificDto
    {
        /// <summary>
        /// 类目名称
        /// </summary>
        public System.String CategoryName { get; set; }

        /// <summary>
        /// 属性名称
        /// </summary>
        public System.String SpecificName { get; set; }

        /// <summary>
        /// API属性名称
        /// </summary>
        public System.String FeedName { get; set; }

        /// <summary>
        /// 数据类型
        /// </summary>
        public System.String DataType { get; set; }

        /// <summary>
        /// 数据格式
        /// </summary>
        public System.String Format { get; set; }

        /// <summary>
        /// 文本最小长度
        /// </summary>
        public System.Int32? MinLength { get; set; }

        /// <summary>
        /// 文本最大长度
        /// </summary>
        public System.Int32? MaxLength { get; set; }

        /// <summary>
        /// 集合最小个数
        /// </summary>
        public System.Int32? MinItems { get; set; }

        /// <summary>
        /// 集合类型
        /// </summary>
        public System.String MinItemType { get; set; }

        /// <summary>
        /// 前端展示类型[文本框text 单选single 多选multiple 带单位unit]
        /// </summary>
        public System.String ShowType { get; set; }

        /// <summary>
        /// 推荐下拉值
        /// </summary>
        public System.String Enums { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.Int32? MiniMum { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.Int32? MaxiNum { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.Boolean? ExclusiveMaximum { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.Decimal? MultipleOf { get; set; }

        /// <summary>
        /// 使用限制[Optional  Recommended  Required]
        /// </summary>
        public System.String UsageConstraint { get; set; }

        /// <summary>
        /// 描述信息
        /// </summary>
        public System.String Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.Int64? ParentId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.String ParentSpecificName { get; set; }

        /// <summary>
        /// 属性值(单个值)
        /// </summary>
        public string SpecificValue { get; set; }

        /// <summary>
        /// 属性值（多个值）
        /// </summary>
        public List<string> SpecificValueList { get; set; } = new List<string>();

        /// <summary>
        /// 
        /// </summary>
        public System.String Group { get; set; }

        //public List<ListerCategorySpecificDto> SubList { get; set; } = new List<ListerCategorySpecificDto>();
        public List<ListerCategorySubSpecificDto> SubList { get; set; } = new List<ListerCategorySubSpecificDto>();
    }

    public class ListerCategorySubSpecificDto
    {

        /// <summary>
        /// 属性名称
        /// </summary>
        public System.String SpecificName { get; set; }
        public System.String FeedSpecificName { get; set; }

        /// <summary>
        /// 属性名称值
        /// </summary>
        public System.String Name { get; set; }


        /// <summary>
        /// 属性值名称
        /// </summary>
        public System.String SpecificValue { get; set; }
        public System.String FeedSpecificValue { get; set; }

        /// <summary>
        /// 属性值值
        /// </summary>
        public System.String Value { get; set; }

        /// <summary>
        /// 推荐下拉值
        /// </summary>
        public System.String Enums { get; set; }
    }
}
