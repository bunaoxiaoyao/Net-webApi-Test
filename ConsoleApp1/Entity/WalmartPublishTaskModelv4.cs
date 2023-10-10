using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Entity
{
    /// <summary>
    /// 沃尔玛改价格Model
    /// </summary>
    public class WalmartPriceModel
    {
        [JsonProperty("amount")]
        public string Amount { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
    }

    /// <summary>
    /// 沃尔玛刊登改价格Model
    /// </summary>
    public class WalmartPublishUpdatePriceModel
    {
        [JsonProperty("price")]
        public WalmartPriceModel Price { get; set; }

        [JsonProperty("sku")]
        public string Sku { get; set; }
    }

    public class WalmartPublishUpdatePriceTaskModel
    {
        [JsonProperty("data")]
        public IList<WalmartPublishUpdatePriceModel> Data { get; set; }
    }

    /// <summary>
    /// 沃尔玛改库存Model
    /// </summary>
    public class WalmartQuantityModel
    {
        [JsonProperty("amount")]
        public string Amount { get; set; }
        [JsonProperty("unit")]
        public string Unit { get; set; }
    }

    /// <summary>
    /// 沃尔玛刊登改库存Model
    /// </summary>
    public class WalmartPublishUpdateQuantityModel
    {
        [JsonProperty("quantity")]
        public WalmartQuantityModel Quantity { get; set; }

        [JsonProperty("sku")]
        public string Sku { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("fulfillmentLagTime")]
        public string FulfillmentLagTime { get; set; }
    }

    public class WalmartPublishUpdateQuantityTaskModel
    {
        [JsonProperty("data")]
        public IList<WalmartPublishUpdateQuantityModel> Data { get; set; }
    }

    /// <summary>
    /// 沃尔玛下架model
    /// </summary>
    public class WalmartPublishEndModel
    {
        [JsonProperty("sku_list")]
        public List<string> SkuLists { get; set; }
    }

    /// <summary>
    /// 沃尔玛物流以及发货信息
    /// </summary>
    public class WalmartOfferInfo
    {
        /// <summary>
        /// 沃尔玛产品库税号
        /// </summary>
        [JsonProperty("ProductTaxCode")]
        public string ProductTaxCode { get; set; }
        /// <summary>
        /// 物流信息(measure，unit)
        /// </summary>
        [JsonProperty("ShippingWeight")]
        public Dictionary<string, string> ShippingWeight { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        [JsonProperty("price")]
        public string Price { get; set; }
    }

    public class WalmartPublishTaskModel
    {
        [JsonProperty("mart")]
        public string Mart { get; set; }
        [JsonProperty("data")]
        public List<WalmartPublishModel> Data { get; set; }
    }

    /// <summary>
    /// 沃尔玛刊登Model
    /// </summary>
    public class WalmartPublishModel
    {
        [JsonProperty("offer")]
        public WalmartOfferInfo Offer { get; set; }
        [JsonProperty("product")]
        public WalmartPublishProduct Product { get; set; }

        [JsonProperty("productIdentifiers")]
        public List<WalmartProductIdentifier> ProductIdentifiers { get; set; }
        [JsonProperty("sku")]
        public string Sku { get; set; }
        [JsonProperty("inventory")]
        public WalmartPublishUpdateQuantityModel Inventory { get; set; }
    }

    /// <summary>
    /// 沃尔玛刊登商品节点
    /// </summary>
    public class WalmartPublishProduct
    {
        [JsonProperty("category")]
        public string Category { get; set; }
        [JsonProperty("sub_category")]
        public string SubCategory { get; set; }
        [JsonProperty("productName")]
        public string ProductName { get; set; }

        [JsonProperty("detail")]
        public Dictionary<string, object> Detail { get; set; }

        [JsonProperty("variantGroupId")]
        public string VariantGroupId { get; set; } = "";

    }

    #region v4沃尔玛刊登模板
    public class Modelv4
    {
        [JsonProperty("data")]
        public WalmartPublishTaskModelv4 Data { get; set; }

        [JsonProperty("Inventory")]
        public List<Inventory> Inventory { get; set; }
    }

    public class WalmartPublishTaskModelv4
    {
        [JsonProperty("MPItemFeedHeader")]
        public MPItemFeedHeader MPItemFeedHeader { get; set; }

        [JsonProperty("MPItem")]
        public List<MPItems> MPItem { get; set; }
    }

    public class Inventory
    {
        [JsonProperty("sku")]
        public string Sku { get; set; }

        [JsonProperty("quantity")]
        public Dictionary<string, object> Quantity { get; set; }

        [JsonProperty("fulfillmentLagTime")]
        public string FulfillmentLagTime { get; set; }
    }

    public class MPItemFeedHeader
    {
        [JsonProperty("subCategory")]
        public string SubCategory { get; set; }

        [JsonProperty("sellingChannel")]
        public string SellingChannel { get; set; } = "marketplace";

        [JsonProperty("processMode")]
        public string ProcessMode { get; set; } = "REPLACE";

        [JsonProperty("locale")]
        public string locale { get; set; } = "en";

        [JsonProperty("version")]
        public string Version { get; set; } = "1.3";

        [JsonProperty("subset")]
        public string Subset { get; set; } = "EXTERNAL";

        [JsonProperty("mart")]
        public string Mart { get; set; } = "WALMART_US";
    }

    // <summary>
    /// 沃尔玛刊登Model v4
    /// </summary>
    public class MPItems
    {

        [JsonProperty("Visible")]
        public object Visible { get; set; }

        [JsonProperty("Orderable")]
        public Dictionary<string, object> Orderable { get; set; }
    }

    public class Visibles
    {
        [JsonProperty("detail")]
        public Dictionary<string, object> Detail { get; set; }
    }
    #endregion
}
