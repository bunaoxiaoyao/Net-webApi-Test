using SqlSugar;

namespace ConsoleApp1.Entity.墨西哥站点
{
    /// <summary>
    /// Walmart范本多属性图片表
    /// </summary>
    [SugarTable("t_bi_walmart_lister_mx_variation_image")]
    public class WalmartListerMxVariationImage
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
        /// 属性值
        /// </summary>
        public System.String SpecificValue { get; set; }

        /// <summary>
        /// 属性图片
        /// </summary>
        public System.String Images { get; set; }

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