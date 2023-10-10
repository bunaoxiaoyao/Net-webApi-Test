using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace ConsoleApp1
{
    ///<summary>
    ///Walmart范本表
    ///</summary>
    [SugarTable("t_bi_walmart_lister")]
    public partial class t_bi_walmart_lister
    {
           public t_bi_walmart_lister(){


           }
           /// <summary>
           /// Desc:主键
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public long Id {get;set;}

           /// <summary>
           /// Desc:账号id
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long AccountId {get;set;}

           /// <summary>
           /// Desc:商品基础刊登主键Id
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string AccountName {get;set;}

           /// <summary>
           /// Desc:仓库商品编码
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string ProCode {get;set;}

           /// <summary>
           /// Desc:平台Sku
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string SkuCode {get;set;}

           /// <summary>
           /// Desc:国家
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Market {get;set;}

           /// <summary>
           /// Desc:产品标题
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string Title {get;set;}

           /// <summary>
           /// Desc:短描述
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string ShortDescription {get;set;}

           /// <summary>
           /// Desc:ProductIdType[GTIN EAN UPC]
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ProductIdType {get;set;}

           /// <summary>
           /// Desc:商品识别码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ProductId {get;set;}

           /// <summary>
           /// Desc:品牌
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Brand {get;set;}

           /// <summary>
           /// Desc:分类名称
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string CategoryName {get;set;}

           /// <summary>
           /// Desc:子分类名称(API使用)
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string SubCategoryName {get;set;}

           /// <summary>
           /// Desc:售价
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? Price {get;set;}

           /// <summary>
           /// Desc:成本
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? Cost {get;set;}

           /// <summary>
           /// Desc:物流单位
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ShippingWeightUnit {get;set;}

           /// <summary>
           /// Desc:物流重量
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? ShippingWeight {get;set;}

           /// <summary>
           /// Desc:产品税号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ProductTaxCode {get;set;}

           /// <summary>
           /// Desc:商品数量
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? Quantity {get;set;}

           /// <summary>
           /// Desc:主图
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string MainImageUrl {get;set;}

           /// <summary>
           /// Desc:删除状态
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public byte IsDeleted {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string DeleteUserName {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string DeleterUserId {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? DeletionTime {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? LastModificationTime {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string LastModifierUserId {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string LastModifierUserName {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? CreationTime {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string CreateUserName {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string CreatorUserId {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string CreatorDepartmentId {get;set;}

           /// <summary>
           /// Desc:
           /// Default:1
           /// Nullable:True
           /// </summary>           
           public string CreatorOrganizeId {get;set;}

    }
}
