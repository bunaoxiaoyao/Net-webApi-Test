using SqlSugar;

namespace ConsoleApp1.Entity.墨西哥站点
{
    /// <summary>
    /// Walmart范本属性表
    /// </summary>
    [SugarTable("t_bi_walmart_lister_mx_specific")]
    public class WalmartListerMxSpecific
    {
        /// <summary>
        /// 主键
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public System.Int64 Id { get; set; }

        /// <summary>
        /// 范本id
        /// </summary>
        public System.Int64 ListerId { get; set; }

        /// <summary>
        /// 属性名称
        /// </summary>
        public System.String SpecificName { get; set; }

        /// <summary>
        /// Api属性名称
        /// </summary>
        public System.String FeedName { get; set; }

        /// <summary>
        /// 产品属性值
        /// </summary>
        public System.String SpecificValue { get; set; }

        /// <summary>
        /// 产品属性值Fr
        /// </summary>
        public System.String SpecificValueFr { get; set; }

        /// <summary>
        /// 语言
        /// </summary>
        public System.String Language { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.String Group { get; set; }

        /// <summary>
        /// 删除状态
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.String DeleteUserName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.String DeleterUserId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.DateTime? DeletionTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.DateTime? LastModificationTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.String LastModifierUserId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.String LastModifierUserName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.DateTime? CreationTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.String CreateUserName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.String CreatorUserId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.String CreatorDepartmentId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.String CreatorOrganizeId { get; set; }
    }
}