using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using ConsoleApp1.Models;
using SqlSugar;
using ConsoleApp1.Helper;

namespace ConsoleApp1.Entity
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("t_bi_walmart_publish_config")]
    public partial class WalmartPublishConfig
    {
        public WalmartPublishConfig()
        {


        }
        /// <summary>
        /// Desc:主键
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public long Id { get; set; }

        /// <summary>
        /// Desc:上架配置名称
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string AddedConfigName { get; set; }

        /// <summary>
        /// Desc:平台类目
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string CategoryId { get; set; }

        /// <summary>
        /// Desc:店铺ID
        /// Default:
        /// Nullable:False
        /// </summary>           
        public long ShopId { get; set; }

        /// <summary>
        /// Desc:店铺简称
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string ShopAlias { get; set; }

        /// <summary>
        /// Desc:店铺名称
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string ShopName { get; set; }

        /// <summary>
        /// Desc:站点
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string Site { get; set; }

        /// <summary>
        /// Desc:1：中国直发 2：中国虚拟仓 3：海外发货
        /// Default:
        /// Nullable:False
        /// </summary>           
        public int DeliveryChannel { get; set; }

        /// <summary>
        /// Desc:号码池Id
        /// Default:
        /// Nullable:False
        /// </summary>           
        public int UpcId { get; set; }

        /// <summary>
        /// Desc:品牌
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string Brand { get; set; }

        /// <summary>
        /// Desc:百伦类目id
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string BaiLunCategoryIds { get; set; }

        /// <summary>
        /// Desc:刊登类型（0：生成范本 1：立即刊登）
        /// Default:
        /// Nullable:False
        /// </summary>           
        public int PublishType { get; set; }

        /// <summary>
        /// Desc:1：在售 2：强制淘汰 3：平台下架  4：清货待下架  5：不在售
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string CanUpGoodsTypeNames { get; set; }

        /// <summary>
        /// Desc:1：在售 2：强制淘汰 3：平台下架  4：清货待下架  5：不在售
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string CanUpGoodsTypeIds { get; set; }

        /// <summary>
        /// Desc:类目名称
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string CanUpCategoryNames { get; set; }

        /// <summary>
        /// Desc:标题
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string TitleConfigJson { get; set; }

        /// <summary>
        /// Desc:FulfillmentCenterID
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string FulfillmentCenterID { get; set; }

        /// <summary>
        /// Desc:ShippingTemplateID
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string ShippingTemplateID { get; set; }

        /// <summary>
        /// Desc:毛利润
        /// Default:
        /// Nullable:True
        /// </summary>           
        public decimal? ProfitRate { get; set; }

        /// <summary>
        /// 主图尺寸
        /// </summary>
        public string MainImageUrlSize { get; set; }

        /// <summary>
        /// 主图颜色
        /// </summary>
        public string MainImageUrlColor { get; set; }

        /// <summary>
        /// 是否大侵权
        /// </summary>
        public bool? IsBigInfringe { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>           
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string DeleteUserName { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string DeleterUserId { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public DateTime? DeletionTime { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public DateTime? LastModificationTime { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string LastModifierUserId { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string LastModifierUserName { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>           
        public DateTime CreationTime { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string CreateUserName { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string CreatorUserId { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string CreatorDepartmentId { get; set; }

        /// <summary>
        /// Desc:
        /// Default:1
        /// Nullable:True
        /// </summary>           
        public string CreatorOrganizeId { get; set; }

        /// <summary>
        /// 标题关键字配置
        /// </summary>
        [SugarColumn(IsIgnore=true)]
        public List<TitleConfig> TitleConfigs
        {
            get
            {
                if (!string.IsNullOrEmpty(TitleConfigJson))
                {
                    return JsonHelper.FromJsonList<TitleConfig>(TitleConfigJson);
                }
                return null;
            }
        }
        //标题配置
        [SugarColumn(IsIgnore = true)]
        public string TitleConfigNames { get; set; }

    }
    public class TitleConfig
    {
        public PublishTitleTypeEnum PublishTitleType { get; set; }
        public string PublishTitleTypeName { get; set; }
        public int Num { get; set; }
        /// <summary>
        /// 是否需要去重，0：否 1：是
        /// </summary>
        public bool IsQuChong { get; set; } = true;
    }
}
