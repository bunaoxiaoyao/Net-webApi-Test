using SqlSugar;

namespace ConsoleApp1.Entity.墨西哥站点
{
    /// <summary>
    /// Walmart范本多属性表
    /// </summary>
    [SugarTable("t_bi_walmart_lister_mx_variation")]
    public class WalmartListerMxVariation
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
        /// 仓库商品编码
        /// </summary>
        public System.String ProCode { get; set; }

        /// <summary>
        /// 平台Sku
        /// </summary>
        public System.String SkuCode { get; set; }

        /// <summary>
        /// 产品标题
        /// </summary>
        public System.String Title { get; set; }

        /// <summary>
        /// 短描述
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
        /// 售价
        /// </summary>
        public System.Decimal? Price { get; set; }

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
        /// 属性名称（En）
        /// </summary>
        public System.String SpecificName { get; set; }

        /// <summary>
        /// 属性值（En）
        /// </summary>
        public System.String SpecificValue { get; set; }

        /// <summary>
        /// 缩略图属性
        /// </summary>
        public System.String SwatchVariantAttribute { get; set; }

        /// <summary>
        /// 缩略图URL
        /// </summary>
        public System.String SwatchImageUrl { get; set; }

        /// <summary>
        /// 主图
        /// </summary>
        public System.String MainImageUrl { get; set; }

        /// <summary>
        /// 是否主属性
        /// </summary>
        public System.String IsPrimaryVariant { get; set; }

        /// <summary>
        /// 属性json
        /// </summary>
        public System.String SpecificJson { get; set; }

        /// <summary>
        /// 删除状态
        /// </summary>
        public System.Boolean IsDeleted { get; set; }

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

        /// <summary>
        /// 刊登FeedID
        /// </summary>
        public System.String FeedId { get; set; }

        /// <summary>
        /// ITEMID
        /// </summary>
        public System.String ItemId { get; set; }

        /// <summary>
        /// WPID
        /// </summary>
        public System.String WpId { get; set; }

        /// <summary>
        /// 刊登处理状态
        /// </summary>
        public System.String IngestionStatus { get; set; }

        /// <summary>
        /// 刊登错误信息
        /// </summary>
        public System.String IngestionErrors { get; set; }

        /// <summary>
        /// 发布状态
        /// </summary>
        public System.String PublishedStatus { get; set; }

        /// <summary>
        /// 生命周期状态
        /// </summary>
        public System.String LifecycleStatus { get; set; }

        /// <summary>
        /// 未发布原因
        /// </summary>
        public System.String UnpublishedReasons { get; set; }

        /// <summary>
        /// 同步库存FeedId
        /// </summary>
        public System.String InventoryFeedId { get; set; }

        /// <summary>
        /// 同步库存处理状态
        /// </summary>
        public System.String InventoryIngestionStatus { get; set; }

        /// <summary>
        /// SKU运输模板feedid
        /// </summary>
        public System.String SkuTemplateMapFeedId { get; set; }

        /// <summary>
        /// SKU运输模板处理状态
        /// </summary>
        public System.String SkuTemplateMapIngestionStatus { get; set; }

        /// <summary>
        /// 存储计算售价的公式表达式
        /// </summary>
        public System.String SalePriceFormula { get; set; }

        /// <summary>
        ///  记录售价公式的运费配置
        /// </summary>
        public System.String DeliveryLogistics { get; set; }
    }
}