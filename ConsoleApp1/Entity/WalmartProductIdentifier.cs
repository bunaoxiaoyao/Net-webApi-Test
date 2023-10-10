using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Entity
{
    public class WalmartProductIdentifier
    {
        [JsonProperty("productId")]
        public string ProductId { get; set; }
        /// <summary>
        /// Id类型
        /// </summary>
        [JsonProperty("productIdType")]
        public string ProductIdType { get; set; }
    }
}
