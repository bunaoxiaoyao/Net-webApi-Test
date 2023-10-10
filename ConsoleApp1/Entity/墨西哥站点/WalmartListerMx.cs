using SqlSugar;

namespace ConsoleApp1.Entity.墨西哥站点
{
    /// <summary>
    /// Walmart范本MX站点表
    /// </summary>
    [SugarTable("t_bi_walmart_lister_mx")]
    public class WalmartListerMx
    {
        /// <summary>
        /// 主键
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public System.Int64 Id { get; set; }

        /// <summary>
        /// 账号id
        /// </summary>
        public System.Int64 AccountId { get; set; }

        /// <summary>
        /// 商品基础刊登主键Id
        /// </summary>
        public System.String AccountName { get; set; }

        /// <summary>
        /// 站点
        /// </summary>
        public System.String Site { get; set; }

        /// <summary>
        /// 仓库商品编码
        /// </summary>
        public System.String ProCode { get; set; }

        /// <summary>
        /// 平台Sku
        /// </summary>
        public System.String SkuCode { get; set; }

        /// <summary>
        /// 产品标题(包含Fr-En)
        /// </summary>
        public System.String Title { get; set; }

        /// <summary>
        /// 短描述(包含Fr-En)
        /// </summary>
        public System.String ShortDescription { get; set; }

        /// <summary>
        /// ProductIdType[GTIN EAN UPC]
        /// </summary>
        public System.String ProductIdType { get; set; }

        /// <summary>
        /// 商品识别码
        /// </summary>
        public System.String ProductId { get; set; }

        /// <summary>
        /// 品牌
        /// </summary>
        public System.String Brand { get; set; }

        /// <summary>
        /// 百伦分类id
        /// </summary>
        public System.String CategoryBailunId { get; set; }

        /// <summary>
        /// 分类名称
        /// </summary>
        public System.String CategoryName { get; set; }

        /// <summary>
        /// 子分类名称(API使用)
        /// </summary>
        public System.String SubCategoryName { get; set; }

        /// <summary>
        /// 售价
        /// </summary>
        public System.Decimal? Price { get; set; }

        /// <summary>
        /// 上架配置Id
        /// </summary>
        public System.Int32 PublishConfigId { get; set; }

        /// <summary>
        /// 成本
        /// </summary>
        public System.Decimal? Cost { get; set; }

        /// <summary>
        /// 物流单位
        /// </summary>
        public System.String ShippingWeightUnit { get; set; }

        /// <summary>
        /// 物流重量
        /// </summary>
        public System.Decimal? ShippingWeight { get; set; }

        /// <summary>
        /// 产品税号
        /// </summary>
        public System.String ProductTaxCode { get; set; }

        /// <summary>
        /// 商品数量
        /// </summary>
        public System.Int32? Quantity { get; set; }

        /// <summary>
        /// 主图
        /// </summary>
        public System.String MainImageUrl { get; set; }

        /// <summary>
        /// Key Features(包含Fr-En)
        /// </summary>
        public System.String KeyFeatures { get; set; }

        /// <summary>
        /// 复制范本id
        /// </summary>
        public System.Int32? SourceFromListerId { get; set; }

        /// <summary>
        /// 范本来源[1手动添加 2Excel导入 3复制 4商品库]
        /// </summary>
        public System.Int32? SourceFrom { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.String FulfillmentCenterID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.String ShippingTemplateID { get; set; }

        /// <summary>
        /// 删除状态
        /// </summary>
        public System.SByte IsDeleted { get; set; }

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
        /// 刊登时间
        /// </summary>
        public System.DateTime? SubmitPublishTime { get; set; }

        /// <summary>
        /// 刊登人姓名
        /// </summary>
        public System.String SubmitPublishUserName { get; set; }

        /// <summary>
        /// 刊登人id
        /// </summary>
        public System.String SubmitPublishUserId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.String CreatorOrganizeId { get; set; }

        /// <summary>
        /// 刊登状态[0草稿 1待上传 2平台已接收 3平台处理中 4平台处理已完成 5平台处理异常 6全部上架成功 7部分上架成功]
        /// </summary>
        public System.SByte PublishStatus { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.String FeedId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.DateTime? FeedSubmissionDate { get; set; }

        /// <summary>
        /// Feed状态[RECEIVED INPROGRESS PROCESSED ERROR]
        /// </summary>
        public System.String FeedStatus { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.Int32? ItemsReceived { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.Int32? ItemsSucceeded { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.Int32? ItemsFailed { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.Int32? IitemsProcessing { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.String IngestionStatus { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.String IngestionErrors { get; set; }

        /// <summary>
        /// 禁用程序重复提交[0否 1禁用]
        /// </summary>
        public System.Boolean DisableLister { get; set; }

        /// <summary>
        /// 编辑类型[1只编辑 2编辑且提交到店铺]
        /// </summary>
        public System.Int32 EditType { get; set; }

        /// <summary>
        /// UPC号码池id(外键)
        /// </summary>
        public System.Int64 UpcId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.String ItemId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.String PublishedStatus { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.String LifecycleStatus { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.String UnpublishedReasons { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.String InventoryIngestionStatus { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.String SkuTemplateMapFeedId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.String SkuTemplateMapIngestionStatus { get; set; }

        /// <summary>
        /// 是否包含侵权词：0 不包含 1 包含
        /// </summary>
        public System.Byte? ContainInfringe { get; set; }

        /// <summary>
        /// 是否多属性
        /// </summary>
        public int IsVariation { get; set; }
    }
}